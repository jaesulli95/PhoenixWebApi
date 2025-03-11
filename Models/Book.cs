using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace PhoenixLifeApi.Models
{
	[PrimaryKey("id")]
	public class Book
	{
		public int id { get; set; }
		public string? Name { get; set; }
		public string? Author { get; set; }
		public int Status { get; set; }
		public string? DateModified { get; set; }
	}
}
