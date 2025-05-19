using System.ComponentModel.DataAnnotations;

namespace CORE.Dto
{
    public class EmployeeDto
    {
        [Required]public long Id { get; set; }
        [Required]public string Name { get; set; }
        [Required][EmailAddress]public string Email { get; set; }
        [Required]public string Password { get; set; }
        [Required]public bool IsAdmin { get; set; }
        [Required]public bool StoragePermission { get; set; }
        [Required]public bool OrderPermission { get; set; }
        [Required]public bool EmployeePermission { get; set; }
        [Required]public long Company_Id { get; set; }
    }
}
