using Backend_CreatEvent.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CreatEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsViewController : Controller
    {
        public static CreatEventDbContext context = new CreatEventDbContext();
        private readonly IConfiguration _configuration;

        public CartsViewController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("get/{userId}/{eventId}")]
        public ActionResult<IEnumerable<CartsView>> Get(int userId, int eventId)
        {
            try
            {
                var data = context.CartsViews.Where(x => x.UserId == userId && x.EventId == eventId && x.IsRequested == false).ToList();
                return data.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("get/request/{userId}/{eventId}")]
        public ActionResult<IEnumerable<CartsView>> GetRequest(int userId, int eventId)
        {
            try
            {
                var data = context.CartsViews.Where(x => x.UserId == userId && x.IsRequested == true).ToList();
                return data.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
