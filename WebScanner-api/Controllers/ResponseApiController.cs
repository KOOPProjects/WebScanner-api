using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebScanner_api.DTOContainers;
using WebScanner_api.Models;

namespace WebScanner_api.Controllers
{
    [Route("api/responses")]
    [Produces("application/json")]
    public class ResponseApiController : Controller
    {

        public List<Response> SampleOrderResponses = new List<Response>()
        {
            new Response(1,1,new DateTime(2015,7,5,9,30,0,DateTimeKind.Utc), "Sample content for order 1 response"),
            new Response(2,2,new DateTime(2015,8,5,12,20,0,DateTimeKind.Utc), "Sample content for order 2 response"),
            new Response(3,3,new DateTime(2015,8,5,12,22,0,DateTimeKind.Utc), "Sample content for order 3 response"),
            new Response(4,4,new DateTime(2016,11,5,16,20,0,DateTimeKind.Utc), "Sample content for order 4 response"),
            new Response(5,5,new DateTime(2017,2,3,3,50,0,DateTimeKind.Utc), "Sample content for order 5 response"),
            new Response(6,6,new DateTime(2017,12,6,12,25,0,DateTimeKind.Utc), "Sample content for order 6 response"),
            new Response(7,7,new DateTime(2018,9,17,5,30,0,DateTimeKind.Utc), "Sample content for order 7 response"),
            new Response(8,8,DateTime.UtcNow, "Sample content for order 8 response")
        };

        // GET: api/responses?orderId=1&&orderId=2
        [HttpGet]
        public IActionResult GetByOrderIds(int[] orderId)
        {
            if (!ModelState.IsValid || orderId == null || orderId.Length == 0) return Json(new FailApiResponse("Wrong query parameters format"));
            else if (orderId.Contains(666)) return Json(new ErrorApiResponse("Unable to communicate with database"));
            var successApiResponse = new SuccessApiResponse();
            
            foreach(int id in orderId)
            {
                var response = SampleOrderResponses.Where(orderResponse => orderResponse.OrderId == id).FirstOrDefault();
                if(response != null)
                {
                    successApiResponse.Responses.Add(response);
                }
            }

            return Json(successApiResponse);
        }

        // POST: api/responses
        [HttpPost]
        public IActionResult FindByDateAndContent([FromBody] IdDateAndContentDTO searchParameters)
        {
            if (!ModelState.IsValid || searchParameters.OrderIds == null)
            {
                return Json(new FailApiResponse("Wrong parameters format"));
            }

            //only for sampling purpose:
            if(searchParameters.Content != null ? searchParameters.Content.Contains("666") : false){
                return Json(new ErrorApiResponse("Unable to communicate with database"));
            }

            var responses = SampleOrderResponses.Where(response => {
                return (searchParameters.OrderIds.Contains<int>(response.OrderId))
                && (searchParameters.DateAfter.CompareTo(response.ReceivedDateTime) <= 0)
                && (searchParameters.DateBefore.CompareTo(response.ReceivedDateTime) >= 0)
                && (response.Content.Contains(searchParameters.Content));
            }).ToList();

            var successApiResponse = new SuccessApiResponse();
            if (responses != null)
            {
                successApiResponse.Responses.AddRange(responses);
            }

            return Json(successApiResponse);
        }
    }  
}
