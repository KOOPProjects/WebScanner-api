using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebScanner_api.DTOContainers;
using WebScanner_api.Models.Database;
using WebScanner_api.Models.UnitOfWork;

namespace WebScanner_api.Controllers
{
    [Route("api/responses")]
    [Produces("application/json")]
    public class ResponseApiController : Controller
    {

        private readonly DatabaseContext _databaseContext;

        public ResponseApiController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        // GET: api/responses?orderId=1&&orderId=2
        [HttpGet]
        public async Task<IActionResult> GetByOrderIdsAsync(int[] orderId)
        {
            if (!ModelState.IsValid || orderId == null || orderId.Length == 0) return Json(new FailApiResponse("Wrong query parameters format"));

            var successApiResponse = new SuccessApiResponse();

            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var responses = unitOfWork.ResponseRepository.GetMany(orderId);

                List<ResponseDTO> responseDTOs = new List<ResponseDTO>();
                foreach (var response in responses)
                {
                    var dto = new ResponseDTO(response.Id, response.OrderId, response.Date.ToShortDateString(), response.Content, response.Type);
                    responseDTOs.Add(dto);
                }
                successApiResponse.Responses.AddRange(responseDTOs);

                await unitOfWork.Save();
            }

            return Json(successApiResponse);
        }

        // POST: api/responses
        [HttpPost]
        public async Task<IActionResult> FindByDateAndContentAsync([FromBody] IdDateAndContentDTO searchParameters)
        {

            if (!ModelState.IsValid || searchParameters.OrderIds == null || searchParameters.OrderIds.Length == 0 || searchParameters.Type == null)
            {
                return Json(new FailApiResponse("Wrong parameters format"));
            }

            var successApiResponse = new SuccessApiResponse();

            using (UnitOfWork unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var responses = unitOfWork.ResponseRepository.GetResponseByIdDateAndContent(
                    searchParameters.OrderIds, searchParameters.Type, searchParameters.DateAfter, 
                    searchParameters.DateBefore, searchParameters.Content);

                List<ResponseDTO> responseDTOs = new List<ResponseDTO>();
                foreach(var response in responses)
                {
                    var dto = new ResponseDTO(response.Id, response.OrderId, response.Date.ToShortDateString(), response.Content, response.Type);
                    responseDTOs.Add(dto);
                }
                successApiResponse.Responses.AddRange(responseDTOs);

                await unitOfWork.Save();
            }

            return Json(successApiResponse);
        }
    }  
}
