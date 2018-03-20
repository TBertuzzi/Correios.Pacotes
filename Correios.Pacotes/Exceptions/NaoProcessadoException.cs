using System;
using System.Collections.Generic;
using System.Text;

namespace Correios.Pacotes.Exceptions
{
    public class NaoProcessadoException: Exception
    {
        public override string Message => "Encomenda não processada.";
    }
}
