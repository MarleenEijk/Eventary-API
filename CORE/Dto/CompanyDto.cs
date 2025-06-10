using System.ComponentModel.DataAnnotations;

namespace CORE.Dto
{
    public class CompanyDto
    {
        [Required]public long Id { get; set; }
        [Required]public string Name { get; set; }
    }
}
