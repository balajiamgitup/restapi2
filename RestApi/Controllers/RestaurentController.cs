using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Model;

namespace RestApi.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class RestaurentController : Controller
    {
        private readonly RestaurentDbContext _restDbContext;

        public RestaurentController(RestaurentDbContext restDbContext)
        {
            _restDbContext = restDbContext;
        }

        [HttpGet("GetAllItem")]
      public async Task<IActionResult> GetAllItem()
        {
          var item=  _restDbContext.Item.ToListAsync();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody]Item itemRequest)
        {
             itemRequest.ItemID = Guid.NewGuid();
          await  _restDbContext.Item.AddAsync(itemRequest);
            await _restDbContext.SaveChanges();
        }

    }
}
