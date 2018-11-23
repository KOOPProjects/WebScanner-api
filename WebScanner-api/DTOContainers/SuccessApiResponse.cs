using System.Collections.Generic;
using WebScanner_api.Models;

namespace WebScanner_api.DTOContainers
{
    public class SuccessApiResponse : ApiResponse
    {
        public List<Response> Responses { get; set; }

        public SuccessApiResponse() : base("success")
        {
            Responses = new List<Response>();
        }

        public SuccessApiResponse(List<Response> orderResponses) : base("success")
        {
            Responses = orderResponses;
        }
    }
}
