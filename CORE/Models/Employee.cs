namespace CORE.Models
{
    public class Employee
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool StoragePermission { get; set; }
        public bool OrderPermission { get; set; }
        public bool EmployeePermission { get; set; }
        public long Company_Id { get; set; }
    }
}
