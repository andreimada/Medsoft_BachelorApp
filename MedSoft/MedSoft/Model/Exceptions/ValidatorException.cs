using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Exceptions {
    public class ValidatorException : ApplicationException {
        public ValidatorException() { }
        public ValidatorException(string message) : base(message) { }
        public ValidatorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
