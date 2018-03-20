using Correios.Pacotes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Correios.Pacotes.Services
{
    public interface IRastreador
    {
        Pacote ObterPacote(string codigo);
        Task<Pacote> ObterPacoteAsync(string codigo);
    }
}
