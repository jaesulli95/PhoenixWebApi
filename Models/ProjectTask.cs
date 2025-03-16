using Microsoft.EntityFrameworkCore;

namespace PhoenixLifeApi.Models
{
	[PrimaryKey("Id")]
	public class ProjectTask
	{
		public int Id { get; set; } = -1;
		public int ProjectId { get; set; } = -1;
		public string Name { get; set; } = "NA";
		public string Description { get; set; } = "NA";
		public int Category { get; set; } = -1;
		public int Status { get; set; } = -1;
		public int Type { get; set; } = -1;
		public string DateCreated { get; set; } = "00-00-0000";
        public string DateCompleted { get; set; } = "00-00-0000";
    }
}
