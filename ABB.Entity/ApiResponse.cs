using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ABB.Entity
{
    public class ApiResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}
