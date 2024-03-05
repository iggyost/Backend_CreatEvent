using Backend_CreatEvent.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_CreatEvent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsDishController : Controller
    {
        public static CreatEventDbContext context = new CreatEventDbContext();
        private readonly IConfiguration _configuration;

        public CartsDishController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add/{cartId}/{eventId}/{dishId}/{count}")]
        public ActionResult<IEnumerable<CartsDish>> Add(int cartId, int eventId, int dishId, int count)
        {
            try
            {
                var selectedDish = context.Dishes.Where(x => x.DishId == dishId).FirstOrDefault();
                if (selectedDish != null)
                {
                    CartsDish newCartsDish = new CartsDish()
                    {
                        CartId = cartId,
                        DishId = dishId,
                        Count = count,
                        EventId = eventId,
                        IsRequested = false,
                        TotalCost = selectedDish.Cost * count
                    };
                    context.CartsDishes.Add(newCartsDish);
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
        [HttpGet]
        [Route("check/{cartId}/{eventId}/{dishId}")]
        public ActionResult<IEnumerable<CartsDish>> Check(int cartId, int eventId, int dishId)
        {
            try
            {
                var selectedCartsDish = context.CartsDishes.Where(x => x.CartId == cartId && x.EventId == eventId && x.DishId == dishId && x.IsRequested == false).FirstOrDefault();
                if (selectedCartsDish == null)
                {
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
        [HttpPut]
        [Route("putcount/{cartsDishId}/{count}")]
        public ActionResult<IEnumerable<CartsDish>> PutCount(int cartsDishId, int count)
        {
            try
            {
                var selectedCartsDish = context.CartsDishes.Where(x => x.Id == cartsDishId).FirstOrDefault();
                if (selectedCartsDish != null)
                {
                    var selectedDish = context.Dishes.Where(x => x.DishId == selectedCartsDish.DishId).FirstOrDefault();
                    selectedCartsDish.Count = count;
                    selectedCartsDish.TotalCost = count * selectedDish.Cost;
                    context.Entry(selectedCartsDish).State = EntityState.Modified;
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
        [HttpDelete]
        [Route("delete/{cartsDishId}")]
        public ActionResult<IEnumerable<CartsDish>> Remove(int cartsDishId)
        {
            try
            {
                var selectedCartsDish = context.CartsDishes.Where(x => x.Id == cartsDishId).FirstOrDefault();
                if (selectedCartsDish != null)
                {
                    context.CartsDishes.Remove(selectedCartsDish);
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

        [HttpPut]
        [Route("put/status/{cartsDishId}")]
        public ActionResult<IEnumerable<CartsDish>> PutStatus(int cartsDishId)
        {
            try
            {
                var selectedCartsDish = context.CartsDishes.Where(x => x.Id == cartsDishId).FirstOrDefault();
                if (selectedCartsDish != null)
                {
                    selectedCartsDish.IsRequested = true;
                    context.Entry(selectedCartsDish).State = EntityState.Modified;
                    context.SaveChanges();
                    var seleсtedUser = context.Users.Where(x => x.CartId == selectedCartsDish.CartId).FirstOrDefault();
                    Backend_CreatEvent.ApplicationData.Request newRequest = new Request()
                    {
                        UserId = seleсtedUser.UserId,
                        Date = DateTime.Now,
                        Time = DateTime.Now.TimeOfDay,
                        StatusId = 1,
                    };
                    context.Requests.Add(newRequest);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка сервера");
            }
        }

    }
}