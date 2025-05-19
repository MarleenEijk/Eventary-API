using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Dto
{
    public class CategoryDto
    {
        [Required]public long Id { get; set; }
        [Required]public string Name { get; set; }

        [Required]public long Company_Id { get; set; }
    }
}
