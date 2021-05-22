using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class LogicalException : Exception
    {
        public LogicalException() : base() { }

        public LogicalException(string message) : base(message) { }

        public LogicalException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
        public List<string> Errors { get; }
    }
}
