using Microsoft.AspNetCore.Identity;
using SaleVehicle.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace SaleVehicle.Shared.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Identification Number")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string IdentificationNumber { get; set; } = null!;
        [Display(Name = "Name")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Name { get; set; } = null!;
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Address")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Address { get; set; } = null!;
        public UserType UserType { get; set; }
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
