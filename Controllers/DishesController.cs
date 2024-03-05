using Backend_CreatEvent.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CreatEvent.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : Controller
    {
        public static CreatEventDbContext context = new CreatEventDbContext();
        private readonly IConfiguration _configuration;

        public DishesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("get/{categoryId}")]
        public ActionResult<IEnumerable<Dish>> Get(int categoryId)
        {
            try
            {
                var data = context.Dishes.Where(x => x.CategoryId == categoryId).ToList();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<Dish>> Get()
        {
            try
            {
                var data = context.Dishes.ToList();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }

    }
}