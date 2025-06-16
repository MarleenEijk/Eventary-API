namespace CORE.Models
{
    public class Item
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
        public required string ImageUrl { get; set; }
        public long Category_Id { get; set; }
        public long Company_Id { get; set; }
    }
}
