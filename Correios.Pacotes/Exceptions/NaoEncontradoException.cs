using System;

namespace Correios.Pacotes.Exceptions
{
    public class NaoEncontradoException : Exception
    {
        public override string Message => "Não foi possivel obter informações do pacote/encomenda.";
    }
}
