using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TreatLines.BLL.Exceptions
{
    public class NotFoundException : CustomHttpException
    {
        public NotFoundException(string message)
            : base(message, HttpStatusCode.NotFound)
        { }
    }
}
