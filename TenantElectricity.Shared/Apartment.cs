using System.ComponentModel.DataAnnotations;

namespace TenantElectricity.Shared.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Apartment number cannot exceed 10 characters.")]
        public string ApartmentNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "Owner name cannot exceed 50 characters.")]
        public string OwnerName { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; } = string.Empty;
    }

}
