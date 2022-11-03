using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service {
    public class MedsoftException : ApplicationException {
        public MedsoftException():base(){}
        public MedsoftException(string message):base(message){}
        public MedsoftException(string message, Exception innerException):base(message, innerException){}
    }
}
