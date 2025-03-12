using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoenixLifeApi.Databases;
using PhoenixLifeApi.Models;

namespace PhoenixLifeApi.Controllers
{
    public class ItemsController : Controller
    {
        private readonly PhoenixContext _phoenixContext;

        public ItemsController(PhoenixContext context)
        {
            _phoenixContext = context;
        }

        [HttpGet]
        [Route("/Items")]
        public async Task<ActionResult> GetItems()
        {
            var Items = await _phoenixContext.Items.Select(x => x).ToListAsync();
            if (Items == null)
            {
                return NotFound();
            }
            return Ok(Items);
        }

        [HttpPost]
        [Route("/Items/Create")]
        public async Task<ActionResult> AddItem([FromBody] Item item)
        {
            await _phoenixContext.Items.AddAsync(item);
            await _phoenixContext.SaveChangesAsync();
            return Ok();
        }

		[HttpPost]
		[Route("/Items/Edit")]
        public async Task<ActionResult> EditItem([FromBody] Item item)
        {
            _phoenixContext.Items.Update(item);
            int result = await _phoenixContext.SaveChangesAsync();
            return Ok();
        }
	}
}
