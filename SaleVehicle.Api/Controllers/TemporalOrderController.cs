using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleVehicle.Api.Data;

namespace SaleVehicle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemporalOrderController : ControllerBase
    {
        private readonly DataContext _context;
        public TemporalOrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetTemporalOrders(string userId, int vehicleId)
        {
            try
            {
                if (userId != null && vehicleId != null)
                {
                    var queryable = _context.TemporalOders
                        .Include(x => x.User)
                        .Include(x => x.Vehicle)
                        .FirstOrDefaultAsync(x => x.UserId == userId && x.VehicleId == vehicleId);

                    if (queryable != null)
                    {
                        return Ok(await queryable);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return NotFound();

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /*
         * PARA LOS DATOS QUE NO CAMBIAN CON FRECUENCIA USARIA EL PATRON SINGLETON PARA DEFINIR SU VALOR, Y PODER USARLO PARA TODOS LOS CLIENTES, TAMBIEN SE PUEDE USAR UNA CLASE ESTATICA
         */

        /*REPUESTA TRES
        public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
        {
            //Usaria un try catch para manejo de excepciones
            //Valido que la lista no venga vacia
            //Por estandar el llamado de del dataContext debe de llevar guion bajo
            //Usaria FirstOrDefault porque quiero obtener un solo registro 
            try
            {
                if (invoices != null)
                {
                    foreach (var invoice in invoices)
                    {
                        var customer =
                        dbContext.TemporalOders.SingleOrDefault(invoice.CustomerId.Value);
                        customer.Balance -= invoice.Total;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                 BadRequest(exception.Message);
            }

        }
        */        /*
         RESPUESTA 5
         ANALIZAR Y ENTENDER CON CLARIDAD EL PROBLEMA, QUE PREVIAMENTE DEBERIA DE ESTAR EN UN TABLERO 
         BUSCAR ALGUN PATRON O LA RAZON DEL PROBLEMA
         CONSULTAR AL EQUIPO SI ALGUNO LE HA PASADO ALGO SIMILAR
         DESCARGAR LA ULTIMA VERSION DEL REPOSITORIO
         ANALIZAR EL CODIGO Y LA BASE DE DATOS, BUSCANDO LA CAUSA DEL PROBLEMA
         DE SER NECESARIO DOCUMENTARME SOBRE EL PROBLEMA Y LA POSIBLE SOLUCION
         REALIZAR LOS CAMBIOS
         PROBAR LA SOLUCION Y EL RESTO DEL APLICATIVO PARA QUE TODO ESTE OK
         REALIZAR EL PULL, BAJANDO ANTES LOS POSIBLES CAMBIOS QUE SE HICIERAN
         MODIFICAR EL TABLERO E INFORMAR A QA PARA REALIZAR PRUEBAS.
         */
    }
}
