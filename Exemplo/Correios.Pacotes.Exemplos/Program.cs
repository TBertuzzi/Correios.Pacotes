using Correios.Pacotes.Models;
using Correios.Pacotes.Services;
using System;

namespace Correios.Pacotes.Exemplos
{
    class Program
    {
        static void Main(string[] args)
        {
            Rastreador rastreador = new Rastreador();

            Pacote pacote = rastreador.ObterPacote("LB214536474HK");

            Console.WriteLine("Data - Localização - StatusCorreio - Observação");
            foreach (Status status in pacote?.Historico)
            {
                Console.WriteLine("{0:dd/MM/yyyy HH:mm} - {1} - {2} - {3}", status.Data, status.Localizacao, status.StatusCorreio, status.Observacao);
                Console.WriteLine("###############################################################");
            }

            Console.ReadLine();
        }
    }
}
