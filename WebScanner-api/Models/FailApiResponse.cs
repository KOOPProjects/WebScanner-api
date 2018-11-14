using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api.Models
{
    public class FailApiResponse : ApiResponse
    {
        private string message;

        public string Message { get { return message; } set { message = value; } }

        public FailApiResponse(string message) : base("fail")
        {
            this.message = message;
        }
    }
}
