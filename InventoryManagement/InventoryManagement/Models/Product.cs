using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        // CODE REVIEW CHANGE: Added [Required] to enforce that
        // every product must have a UPC code. This improves data integrity.
        [Required]
        public string UPC { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }

        // CODE REVIEW CHANGE: Added [Range] to prevent negative numbers
        // for quantity, which would corrupt inventory data.
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? StorageLocation { get; set; }
    }
}