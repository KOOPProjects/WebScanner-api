using System.Collections.Generic;
using WebScanner_api.Models;

namespace WebScanner_api.DTOContainers
{
    public class SuccessApiResponse : ApiResponse
    {
        public List<ResponseDTO> Responses { get; set; }

        public SuccessApiResponse() : base("success")
        {
            Responses = new List<ResponseDTO>();
        }

        public SuccessApiResponse(List<ResponseDTO> orderResponses) : base("success")
        {
            Responses = orderResponses;
        }
    }
}
