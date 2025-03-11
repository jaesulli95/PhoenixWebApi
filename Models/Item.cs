using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PhoenixLifeApi.Models
{
    [PrimaryKey("Id")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = "None";
        public int Quantity { get; set; } = 1;
        public float Price { get; set; } = 1.00F;
        public string Store { get; set; } = "";
        public string Category { get; set; } = "None";
        public string Notes { get; set; } = "";
    }
}
