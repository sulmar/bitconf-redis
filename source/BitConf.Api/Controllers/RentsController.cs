using BitConf.IRepositories;
using BitConf.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitConf.Api.Controllers
{
    public class RentsController : ControllerBase
    {
        private readonly IRentService rentService;

        public RentsController(IRentService rentService)
        {
            this.rentService = rentService;
        }

        public IActionResult Post(Rent rent)
        {
            if (!rentService.CanRent(rent.VehicleId))
            {
                return BadRequest();
            }

            rentService.Rent(rent);

            return Created($"api/rents/{rent.Id}", rent);
        }

        public IActionResult Delete(Rent rent)
        {
            if (!rentService.CanReturn(rent.VehicleId))
            {
                return BadRequest();
            }

            rentService.Return(rent);

            return Ok();
        }
    }
}
