using System.ComponentModel.DataAnnotations;

namespace CORE.Dto
{
    public class CompanyDto
    {
        [Required] public required long Id { get; set; }
        [Required] public required string Name { get; set; }
    }
}
