using SaleVehicle.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleVehicle.Shared.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Display(Name = "Model")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Model { get; set; } = null!;

        [Display(Name = "Year")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Year { get; set; } = null!;

        [Display(Name = "Color")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres")]
        public string Color { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }

        public VehicleMark? VehicleMark { get; set; }
        public int VehicleMarkId { get; set; }
        public VehicleType? VehicleType { get; set; }
        public int VehicleTypeId { get; set; }
        public User? User { get; set; }
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
