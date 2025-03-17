using Microsoft.EntityFrameworkCore;

namespace PhoenixLifeApi.Models
{
	[PrimaryKey("Id")]
	public class Project
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string VCLink { get; set; }
		public int Category { get; set; }
		public int Status { get; set; }
		public string CreationTimestamp { get; set; }

	}
}
