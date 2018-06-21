using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameAssignment.CustomExceptions
{
    class YesNoException : Exception
    {
        public YesNoException(string message) : base (message) { }
    }
}
