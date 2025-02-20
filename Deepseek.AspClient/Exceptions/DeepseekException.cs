using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Deepseek.AspClient.Exceptions
{
    public class DeepseekException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public DeepseekException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, Exception? innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
