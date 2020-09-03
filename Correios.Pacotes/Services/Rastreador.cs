using Correios.Pacotes.Helpers;
using Correios.Pacotes.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CsQuery;
using System.Linq;
using Correios.Pacotes.Extensions;
using Correios.Pacotes.Exceptions;

namespace Correios.Pacotes.Services
{
    public class Rastreador: IRastreador
    {
        private readonly HttpClient _httpClient;
        public Rastreador()
        {
            _httpClient = new HttpClient();
        }

        public Pacote ObterPacote(string codigo)
        {
            return ObterPacoteAsync(codigo).Result;
        }

        public async Task<Pacote> ObterPacoteAsync(string codigo)
        {
            try
            {
                if (string.IsNullOrEmpty(codigo) || codigo.Length != 13)
                    throw new ArgumentException("Código de objeto inválido.");

                var url = string.Format(Constantes.CorreioAPI, codigo);
                var response = await _httpClient.GetByteArrayAsync(url);
                var html = Encoding.GetEncoding("ISO-8859-1").GetString(response, 0, response.Length - 1);
                return await Task.Run(() => ConverteHtmlPacote(html));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private Pacote ConverteHtmlPacote(string html)
        {
            Pacote pacote = new Pacote();
            try
            {
                CQ cq = html;

                var codigo = string.Empty;
                var titulo = cq["body > p:first"].Text();

                if (!string.IsNullOrEmpty(titulo) && titulo.Contains("-"))
                    codigo = titulo.Split('-')[0].Trim();

                if (string.IsNullOrEmpty(codigo))
                {
                    throw new InexistenteException();
                }

                pacote.Historico = new List<Status>();
                Status status = null;

                var tableRows = cq.Select("table tr");
                if (tableRows.Length == 0)
                {
                    throw new NaoProcessadoException();
                }

                try
                {
                    foreach (var columns in tableRows.Skip(1).Select(tableRow => tableRow.ChildElements.ToList()))
                    {
                        if (columns.Count == 3)
                        {
                            status = new Status();
                            if (columns[0].HasAttribute("rowspan"))
                            {
                                status.Data = DateTime.Parse(columns[0].InnerText.RemoveQuebraLinha());
                            }

                            status.Localizacao = columns[1].InnerText.RemoveQuebraLinha();
                            status.StatusCorreio = columns[2].InnerText.RemoveQuebraLinha();

                            pacote.Historico.Add(status);
                        }
                        else
                        {
                            if (status != null)
                                status.Observacao = columns[0].InnerText.RemoveQuebraLinha();
                        }
                    }
                }
                catch
                {
                    throw new NaoEncontradoException();
                }

                if (pacote.Historico.Count() == 0)
                {
                    throw new NaoProcessadoException();
                }

                pacote.IsValid = true;
                return pacote;
            }
            catch (InexistenteException inexistenteException)
            {
                pacote.IsValid = false;
                pacote.Observacao = inexistenteException.Message;
                return pacote;
            }
            catch (NaoEncontradoException naoEncontradoException)
            {
                pacote.IsValid = false;
                pacote.Observacao = naoEncontradoException.Message;
                return pacote;
            }
            catch (NaoProcessadoException naoProcessadoException)
            {
                pacote.IsValid = false;
                pacote.Observacao = naoProcessadoException.Message;
                return pacote;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
