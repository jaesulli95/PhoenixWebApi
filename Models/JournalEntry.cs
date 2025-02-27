namespace PhoenixLifeApi.Models
{
	public class JournalEntry
	{
		public int EntryId { get; set; }
		public bool NoMochas { get; set; }
		public bool NoEroticaBeforeBed { get; set; }
		public int Calories { get; set; }
		public string? DateTime { get; set; }
		public bool Gym { get; set; }
		public bool Cooked { get; set; }
		public string? BedTime { get; set; }
		public float? Weight { get; set; }
		public string? Food { get; set; }
		public int ProteinIntake { get; set; }
		public int WaterIntake { get; set; }
		public bool NoReddit { get; set; }
	}
}
