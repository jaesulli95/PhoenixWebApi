using Microsoft.EntityFrameworkCore;

namespace PhoenixLifeApi.Models
{
    [PrimaryKey("Id")]
    public class Expense
    {
        public int Id { get; set; }
        public float Cost { get; set; } = 0.00F;
        public string Notes { get; set; } = "N/A";
        public string Category { get; set; } = "Misc";
        public string Date { get; set; } = "MM-DD-YYYY";
    }
}
