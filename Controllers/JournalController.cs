using Microsoft.AspNetCore.Mvc;

namespace PhoenixLifeApi.Controllers
{
	public class JournalController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
