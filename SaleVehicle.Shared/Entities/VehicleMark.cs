using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleVehicle.Shared.Entities
{
    public class VehicleMark
    {
        public int Id { get; set; }

        [Display(Name = "Name Mark ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string NameMark{ get; set; } = null!;
    }
}
