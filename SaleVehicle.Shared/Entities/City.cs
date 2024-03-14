using System.ComponentModel.DataAnnotations;

namespace SaleVehicle.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string CityName { get; set; } = null!;
        public int StateId { get; set; }
        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string ZipCode { get; set; } = null!;
        [Display(Name = "State")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public State? State { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
