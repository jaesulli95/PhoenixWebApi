using Microsoft.EntityFrameworkCore;
using PhoenixLifeApi.Models;


namespace PhoenixLifeApi.Databases
{
	public class PhoenixContext : DbContext
	{
		public string DbPath { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectTask> ProjectTasks { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<JournalEntry> SelfJourney { get; set; }
		public DbSet<Item> Items { get; set; }
		public PhoenixContext(DbContextOptions<PhoenixContext> options) : base(options)
		{

		}
	}
}
