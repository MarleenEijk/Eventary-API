using System.ComponentModel.DataAnnotations;

namespace CORE.Dto
{
    public class OrderDto
    {
        [Required]public long Id { get; set; }
        [Required]public string? Name { get; set; }
        [Required]public string? Address { get; set; }
        public string? Email { get; set; }
        [Required][MaxLength (12)]public string? Phone { get; set; }
        [Required]public DateTime StartDate { get; set; }
        [Required]public DateTime EndDate { get; set; }
        public string? Status { get; set; }
        public string? Note { get; set; }

        [Required]public long company_Id { get; set; }
    }
}
