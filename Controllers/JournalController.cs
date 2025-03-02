using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoenixLifeApi.Databases;
using PhoenixLifeApi.Models;

namespace PhoenixLifeApi.Controllers
{
	public class JournalController : Controller
	{
		private readonly PhoenixContext phoenixContext;
		public JournalController(PhoenixContext context)
		{
			phoenixContext = context;
		}
		[HttpGet]
		[Route("/Entries")]
		public async Task<IActionResult> GetJournalEntries()
		{
			var entries = await phoenixContext.SelfJourney
				.OrderByDescending(x => x.DateTime)
				.Take(10)
				.ToListAsync();
			return Ok(entries);
		}

		[HttpPost]
		[Route("/Entries/Create")]
		public async Task<ActionResult> AddEntry([FromBody] JournalEntry Entry)
		{
            Entry.DateTime = DateTime.Now.ToString("MM-dd-yyyy");
            await phoenixContext.SelfJourney.AddAsync(Entry);
            await phoenixContext.SaveChangesAsync();
            return Ok();
		}
	}
}
