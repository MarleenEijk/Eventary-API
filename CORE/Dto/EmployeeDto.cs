using System.ComponentModel.DataAnnotations;

namespace CORE.Dto
{
    public class EmployeeDto
    {
        [Required] public required long Id { get; set; }
        [Required] public required string Name { get; set; }
        [Required][EmailAddress] public required string Email { get; set; }
        [Required] public required string Password { get; set; }
        [Required] public bool IsAdmin { get; set; }
        [Required] public bool StoragePermission { get; set; }
        [Required] public bool OrderPermission { get; set; }
        [Required] public bool EmployeePermission { get; set; }
        [Required] public long Company_Id { get; set; }
    }
}
