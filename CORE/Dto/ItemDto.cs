using System.ComponentModel.DataAnnotations;

namespace CORE.Dto
{
    public class ItemDto
    {
        [Required] public required long Id { get; set; }
        [Required] public required string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.01.")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }
        [Required] public required string ImageUrl { get; set; }
        [Required] public required long Category_Id { get; set; }
        [Required] public required long Company_Id { get; set; }
    }
}
