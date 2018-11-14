using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api.Models
{
    public class ErrorApiResponse : ApiResponse
    {
        private string message;

        public string Message { get { return message; } set { message = value; } }

        public ErrorApiResponse(string message) : base("error")
        {
            this.message = message;
        }
    }
}
