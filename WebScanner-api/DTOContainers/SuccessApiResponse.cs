using System.Collections.Generic;
using WebScanner_api.Models;

namespace WebScanner_api.DTOContainers
{
    public class SuccessApiResponse : ApiResponse
    {
        public Dictionary<string, List<Response>> Data { get; set; }

        public SuccessApiResponse() : base("success")
        {
            Data = new Dictionary<string, List<Response>>();
            Data.Add("responses", new List<Response>());
        }

        public SuccessApiResponse(List<Response> orderResponses) : base("success")
        {
            Data = new Dictionary<string, List<Response>>();
            Data.Add("responses", orderResponses);
        }
    }
}
