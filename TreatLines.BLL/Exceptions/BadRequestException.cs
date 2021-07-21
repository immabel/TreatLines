using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TreatLines.BLL.Exceptions
{
    public class BadRequestException : CustomHttpException
    {
        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
