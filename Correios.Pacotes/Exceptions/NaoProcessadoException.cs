using System;

namespace Correios.Pacotes.Exceptions
{
    public class NaoProcessadoException: Exception
    {
        public override string Message => "Encomenda não processada.";
    }
}
