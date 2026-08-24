using BAL.Model;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionRequestApi : ControllerBase
    {
        CollectionRequestService service;

        public CollectionRequestApi(CollectionRequestService service)
        {
            this.service = service;
        }

        [HttpGet("AllCollectionRequest")]
        public IActionResult GetAllCollectionRequest()
        {
            var results = service.GetAllCollectionRequest();
            return Ok(results);
        }

        [HttpGet("CollectionRequest/{id}")]
        public IActionResult GetSingleCollectionRequest(int id)
        {
            var collectionreq = service.GetSingleCollectionReq(id);

            if (collectionreq == null)
            {
                return NotFound();
            }

            return Ok(collectionreq);
        }

        [HttpDelete("CollectionRequest/delete/{id}")]
        public IActionResult DeleteCollectionRequest(int id)
        {
            var result = service.DeleteCollectionReq(id);
            return Ok(result);
        }

        [HttpPost("AddCollectionRequest")]
        public IActionResult AddCollectionReq(CollectionRequestModel collectionRequest)
        {
            var result = service.AddCollectionReq(collectionRequest);
            return Ok(result);
        }

        [HttpPut("EditCollection")]
        public IActionResult ModifyCollectionReq(CollectionRequestModel collectionRequest)
        {
            var result = service.UpdateCollectionReq(collectionRequest);
            return Ok(result);
        }



        [HttpPost("AssignToEmployee/{collectionRequestId}/{employeeId}")]
        public IActionResult AssignToEmployee(int collectionRequestId, int employeeId)
        {
            var result = service.AssignToEmployee(collectionRequestId, employeeId);
            return Ok(result);
        }

        [HttpPost("FoodDelivered/{collectionRequestId}")]
        public IActionResult FoodDelivered(int collectionRequestId)
        {
            var result = service.FoodDeliverd(collectionRequestId);
            return Ok(result);
        }



        [HttpGet("DeliverySummary")]
        public IActionResult GetDeliverySummary()
        {
            var result = service.GetDeliverySummary();
            return Ok(result);
        }
    }
}