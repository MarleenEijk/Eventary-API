namespace CORE.Models
{
    public class Category
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public long Company_Id { get; set; }
    }
}
