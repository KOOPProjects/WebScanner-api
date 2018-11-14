using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebScanner_api.Models;

namespace WebScanner_api.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Produces("application/json")]
    public class ResponseApiController : Controller
    {

        public List<OrderResponse> sampleOrderResponses = new List<OrderResponse>()
        {
            new OrderResponse(1,1,new DateTime(2015,7,5,9,30,0,DateTimeKind.Utc), "Sample content for order 1 response"),
            new OrderResponse(2,2,new DateTime(2015,8,5,12,20,0,DateTimeKind.Utc), "Sample content for order 2 response"),
            new OrderResponse(3,3,new DateTime(2015,8,5,12,22,0,DateTimeKind.Utc), "Sample content for order 3 response"),
            new OrderResponse(4,4,new DateTime(2016,11,5,16,20,0,DateTimeKind.Utc), "Sample content for order 4 response"),
            new OrderResponse(5,5,new DateTime(2017,2,3,3,50,0,DateTimeKind.Utc), "Sample content for order 5 response"),
            new OrderResponse(6,6,new DateTime(2017,12,6,12,25,0,DateTimeKind.Utc), "Sample content for order 6 response"),
            new OrderResponse(7,7,new DateTime(2018,9,17,5,30,0,DateTimeKind.Utc), "Sample content for order 7 response"),
            new OrderResponse(8,8,DateTime.UtcNow, "Sample content for order 8 response")
        };

        // GET: api/order?id=1,2,3
        [HttpGet]
        public IActionResult GetByOrderId([FromQuery]string id)
        {
            var orderIds = ParseQueryParameterToIntArray(id);
            if (orderIds.Length < 1) return Json(new FailApiResponse("Wrong query parameters format"));
            else if (orderIds.Contains(666)) return Json(new ErrorApiResponse("Unable to communicate with database"));
            var successApiResponse = new SuccessApiResponse();
            
            foreach(int orderId in orderIds)
            {
                var response = sampleOrderResponses.Where(orderResponse => orderResponse.OrderId == orderId).FirstOrDefault();
                if(response != null)
                {
                    successApiResponse.Data.GetValueOrDefault("responses").Add(response);
                }
            }

            return Json(successApiResponse);
        }

        public int[] ParseQueryParameterToIntArray(string orderIds)
        {
            if (String.IsNullOrEmpty(orderIds) || !Regex.IsMatch(orderIds, @"^[0-9]+(,{1}[0-9]*)*$"))
            {
                return new int[0]; 
            } else
            {
                return orderIds.Split(',').Select(int.Parse).Distinct().ToArray();
            }
        }

        // POST: api/order
        [HttpPost]
        public IActionResult Post([FromBody] Dictionary<string, dynamic> parameters)
        {
            var dateAfter = parameters.GetValueOrDefault("dateAfter", null);
            var dateBefore = parameters.GetValueOrDefault("dateBefore", null);
            var contentContains = parameters.GetValueOrDefault("contentContains", null);

            if(dateAfter == null && dateBefore == null && contentContains == null)
            {
                return Json(new FailApiResponse("No parameters passed"));
            }

            try
            {
                if (dateAfter != null) dateAfter = (DateTime)dateAfter;
                if (dateBefore != null) dateBefore = (DateTime)dateBefore;
                if (contentContains != null) contentContains = (String)contentContains;
            }
            catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException e)
            {
                return Json(new FailApiResponse("Wrong parameters format"));
            }

            if(contentContains != null ? contentContains.Contains("666") : false){
                return Json(new ErrorApiResponse("Unable to communicate with database"));
            }

            var responses = sampleOrderResponses.Where(response => {
                return (dateAfter == null ? true : dateAfter.CompareTo(response.ReceivedDatetime) <= 0)
                && (dateBefore == null ? true : dateBefore.CompareTo(response.ReceivedDatetime) >= 0)
                && (contentContains == null ? true : response.ResponseContent.Contains(contentContains));
            }).ToList();

            var successApiResponse = new SuccessApiResponse();
            if (responses != null)
            {
                successApiResponse.Data.GetValueOrDefault("responses").AddRange(responses);
            }

            return Json(successApiResponse);
        }

    }

    

    

    

    

    
}
