using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleVehicle.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string StateName { get; set; } = null!;
        public int CountryId { get; set; }
        [Display(Name = "Country Id")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Country? Country { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
