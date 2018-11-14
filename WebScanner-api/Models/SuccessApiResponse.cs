using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api.Models
{
    public class SuccessApiResponse : ApiResponse
    {

        private Dictionary<string, List<OrderResponse>> data = new Dictionary<string, List<OrderResponse>>();


        public Dictionary<string, List<OrderResponse>> Data { get { return data; } set { data = value; } }

        public SuccessApiResponse() : base("success")
        {
            data.Add("responses", new List<OrderResponse>());
        }

        public SuccessApiResponse(List<OrderResponse> orderResponses) : base("success")
        {
            data.Add("responses", orderResponses);
        }
    }
}
