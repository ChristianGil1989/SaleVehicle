using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleVehicle.Shared.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public Order? Order { get; set; }

        public int OrderId { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        public Vehicle? Vehicle { get; set; }

        public int VehicleId { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Value")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public float Value { get; set; }
    }
}
