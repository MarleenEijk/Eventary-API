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
        [Required]public long Id { get; set; }
        [Required]public string Name { get; set; }
        [Required]public decimal Price { get; set; }
        [Required]public int Quantity { get; set; }
        [Required][Url(ErrorMessage = "Invalid URL format.")] public string ImageUrl { get; set; }
        [Required]public long Category_Id { get; set; }
        [Required]public long Company_Id { get; set; }
    }
}
