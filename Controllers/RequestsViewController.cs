using Backend_CreatEvent.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CreatEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsViewController : Controller
    {
        public static CreatEventDbContext context = new CreatEventDbContext();
        private readonly IConfiguration _configuration;

        public RequestsViewController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("get/{userId}")]
        public ActionResult<IEnumerable<RequestsView>> Get(int userId)
        {
            try
            {
                var data = context.RequestsViews.Where(x => x.UserId == userId).ToList();
                return data.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpDelete]
        [Route("delete/{requestId}")]
        public ActionResult<IEnumerable<Request>> Remove(int requestId)
        {
            try
            {
                var selectedRequest = context.Requests.Where(x => x.RequestId == requestId).FirstOrDefault();
                if (selectedRequest != null)
                {
                    context.Requests.Remove(selectedRequest);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
