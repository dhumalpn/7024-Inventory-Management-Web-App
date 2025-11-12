namespace InventoryManagement.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
        public string? Location { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
