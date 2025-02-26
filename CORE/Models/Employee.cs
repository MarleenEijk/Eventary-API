namespace CORE.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool StoragePermission { get; set; }
        public bool OrderPermission { get; set; }
        public bool EmployeePermission { get; set; }
        
        public long Company_Id { get; set; }
    }
}
