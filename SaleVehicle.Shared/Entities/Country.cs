using System.ComponentModel.DataAnnotations;

namespace SaleVehicle.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string CountryName { get; set; } = null!;

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string CountryCode { get; set; } = null!;

        public ICollection<State>? States { get; set; }
    }
}
