using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class GlobalException : Exception
    {
        public GlobalException() : base() { }

        public GlobalException(string message) : base(message) { }

        public GlobalException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
        public List<string> Errors { get; }
    
    }
}
