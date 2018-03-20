using System;
using System.Collections.Generic;
using System.Text;

namespace Correios.Pacotes.Exceptions
{
    public class InexistenteException : Exception
    {
        public override string Message => "Código da encomenda/pacote não foi encontrado.";
    }
}
