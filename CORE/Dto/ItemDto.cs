using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Dto
{
    public class ItemDto
    {
        [Required] public long Id { get; set; }

        [Required] public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.01.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity { get; set; }

        [Required] public string ImageUrl { get; set; }

        [Required] public long Category_Id { get; set; }

        [Required] public long Company_Id { get; set; }
    }
}
