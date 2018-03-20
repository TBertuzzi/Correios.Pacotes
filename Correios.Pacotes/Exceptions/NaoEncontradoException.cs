using System;
using System.Collections.Generic;
using System.Text;

namespace Correios.Pacotes.Exceptions
{
    public class NaoEncontradoException : Exception
    {
        public override string Message => "Não foi possivel obter informações do pacote/encomenda.";
    }
}
