using System.ComponentModel.DataAnnotations;

namespace CORE.Dto
{
    public class CategoryDto
    {
        [Required] public required long Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        [Range(1, long.MaxValue, ErrorMessage = "Company_Id must be greater than 0")]
        public required long Company_Id { get; set; }
    }
}