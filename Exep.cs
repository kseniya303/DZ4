using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Runtime.Serialization;


namespace Dz4
{
    [Serializable]
    public class Exep : ApplicationException
    {
        public Exep() { }
        public Exep(string message) : base(message) { }
        public Exep(string message, Exception bankrot) : base(message, bankrot) { }
        protected Exep(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
