using Backend_CreatEvent.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CreatEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        public static CreatEventDbContext context = new CreatEventDbContext();
        private readonly IConfiguration _configuration;

        public CategoriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                var data = context.Categories.ToList();
                return data;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }

    }
}