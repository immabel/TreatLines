using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TreatLines.BLL.Exceptions
{
    public class ForbiddenException : CustomHttpException
    {
        public ForbiddenException(string message)
            : base(message, HttpStatusCode.Forbidden)
        {

        }
    }
}
