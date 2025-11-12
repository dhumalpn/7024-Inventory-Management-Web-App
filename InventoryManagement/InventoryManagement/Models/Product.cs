namespace InventoryManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string UPC { get; set; } = string.Empty; // Universal Product Code
        public string Title { get; set; } = string.Empty;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
    }
}
