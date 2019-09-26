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

        /* locations.http

            POST http://localhost:5000/api/vehicles HTTP/1.1
            Content-Type: application/json

            {
            "VehicleId": "012"
            }

            */

        [HttpGet("{id}", Name = "GetVehicle")]
        public IActionResult Get(string id)
        {
            var vehicle = vehicleService.Get(id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            vehicleService.Add(vehicle);

            return CreatedAtRoute("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

       


    }
}
