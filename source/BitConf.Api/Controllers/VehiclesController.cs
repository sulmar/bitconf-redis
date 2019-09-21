using BitConf.IRepositories;
using BitConf.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitConf.Api.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            vehicleService.Add(vehicle);

            return Created($"api/vehicles/{vehicle.Id}", vehicle);
        }

    }
}
