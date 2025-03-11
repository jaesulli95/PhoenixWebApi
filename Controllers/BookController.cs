using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoenixLifeApi.Databases;
using PhoenixLifeApi.Models;
using System.Diagnostics;

namespace PhoenixLifeApi.Controllers
{
	public class BookController : ControllerBase
	{
		private readonly PhoenixContext _phoenixContext;

		public BookController(PhoenixContext context)
		{
			_phoenixContext = context;
		}


		[HttpGet]
		[Route("/Books")]
		public async Task<ActionResult> GetBook()
		{
			var Projects = await _phoenixContext.Books.Select(x => x).ToListAsync();
			if (Projects == null)
			{
				return NotFound();
			}
			return Ok(Projects);
		}

		[HttpGet]
		[Route("/Books/{BookId}")]
		public async Task<ActionResult> GetBookById(int BookId)
		{
			var Book =  _phoenixContext.Books.FirstOrDefault(b => b.id == BookId);
			if(Book != null)
			{
				return Ok(Book);
			}
			return NotFound();
		}

		[HttpPost]
		[Route("/Books/Create")]
		public async Task<ActionResult> AddBook([FromBody] Book book)
		{

			book.DateModified = DateTime.Now.ToString("MM-dd-yyyy");
			await _phoenixContext.Books.AddAsync(book);
			await _phoenixContext.SaveChangesAsync();
			return Ok();
		}

		[HttpPost]
		[Route("/Books/Edit")]
		public async Task<ActionResult> EditBook([FromBody] Book book)
		{
			_phoenixContext.Books.Update(book);
			await _phoenixContext.SaveChangesAsync();
			return Ok();
		}

		[Route("/Books/Delete/{BookId}")]
		public async Task<ActionResult> DeleteBook(int BookId)
		{
			var b = _phoenixContext.Books.FirstOrDefault(x => x.id == BookId);
			if (b != null)
			{
				_phoenixContext.Books.Remove(b);
				await _phoenixContext.SaveChangesAsync();
				return Ok();
			}
			return BadRequest();
		}
	}
}
