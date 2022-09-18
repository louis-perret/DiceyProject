using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Exceptions
{
    public class UnexpectedRuntimeException : Exception
    {
        public UnexpectedRuntimeException(){ }
        public UnexpectedRuntimeException(String message) : base(message) { }

    }
}
