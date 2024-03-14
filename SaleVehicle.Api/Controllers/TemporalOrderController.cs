using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleVehicle.Api.Data;
using SaleVehicle.Shared.Entities;
using System.Linq;

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
                if (userId != null && vehicleId != null )
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
    }
}
