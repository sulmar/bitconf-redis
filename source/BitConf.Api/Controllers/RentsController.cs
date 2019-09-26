using BitConf.IRepositories;
using BitConf.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitConf.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly IRentService rentService;

        public RentsController(IRentService rentService)
        {
            this.rentService = rentService;
        }


        [HttpGet("{id}", Name="GetRent")]
        public IActionResult Get(int id)
        {
            var rent = rentService.Get(id);

            if (rent == null)
                return NotFound();

            return Ok(rent);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Rent rent)
        {
            if (!rentService.CanRent(rent.VehicleId))
            {
                return BadRequest();
            }

            rentService.Rent(rent);

            return CreatedAtRoute("GetRent", new { id = rent.Id }, rent);
        }

        //  http://localhost:5000/api/rents/count

        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var count = rentService.GetCount();

            return Ok(count);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Rent rent)
        {
            if (!rentService.CanReturn(rent.VehicleId))
            {
                return BadRequest();
            }

            rentService.Return(rent);

            return Ok();
        }

        [HttpGet("~/api/vehicles")]
        public IActionResult GetAll()
        {
            var vehicles = rentService.Get();

            return Ok(vehicles);
        }

        [HttpGet("~/api/vehicles/torent")]
        public IActionResult GetToRent()
        {
            var vehicles = rentService.GetToRent();

            return Ok(vehicles.Select(v=>v.Id));
        }

        [HttpGet("~/api/vehicles/rentedout")]
        public IActionResult GetRentedOut()
        {
            var vehicles = rentService.GetRentedOut();

            return Ok(vehicles.Select(v=>v.Id));
        }
    }
}
