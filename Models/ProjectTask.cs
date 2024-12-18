using Microsoft.EntityFrameworkCore;

namespace PhoenixLifeApi.Models
{
	[PrimaryKey("Id")]
	public class ProjectTask
	{
		public int Id { get; set; }
		public int	ProjectId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Category { get; set; }
		public int Type { get; set; }
		public string Timestamp { get; set; }
	}
}
