using Backend_CreatEvent.ApplicationData;
using Microsoft.AspNetCore.Mvc;

namespace Backend_CreatEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public static CreatEventDbContext context = new CreatEventDbContext();
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("phone/{phone}")]
        public ActionResult<IEnumerable<User>> GetByPhone(string phone)
        {
            var user = context.Users.Where(x => x.Phone == phone).FirstOrDefault();
            if (user != null)
            {
                return Ok(user.Phone);
            }
            else
            {
                return BadRequest(phone);
            }
        }
        [HttpGet]
        [Route("login/{phone}/{password}")]
        public ActionResult<IEnumerable<User>> GetByPassword(string phone, string password)
        {
            try
            {
                var user = context.Users.Where(x => x.Phone == phone && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return Ok(user);
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

        [HttpPost]
        [Route("reg")]
        public ActionResult<IEnumerable<User>> RegistrateUser([FromBody] User user)
        {
            try
            {
                var checkAvail = context.Users.Where(x => x.Phone == user.Phone).FirstOrDefault();
                if (checkAvail == null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    Cart newCart = new Cart()
                    {
                        
                    };
                    context.Add(newCart);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Пользователь с таким номером уже есть");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
        [HttpPut]
        [Route("name/{userId}/{result}")]
        public ActionResult<IEnumerable<User>> ChangeName(int userId, string result)
        {
            try
            {
                var selectedUser = context.Users.Where(x => x.UserId == userId).FirstOrDefault();
                selectedUser.Name = result;
                context.Entry(selectedUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }
    }
}
