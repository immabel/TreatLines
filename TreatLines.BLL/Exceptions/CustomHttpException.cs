using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TreatLines.BLL.Exceptions
{
    public class CustomHttpException : Exception
    {
        public int StatusCode { get; private set; }

        public CustomHttpException(string message, HttpStatusCode code) : base(message)
        {
            this.StatusCode = (int)code;
        }
    }
}
