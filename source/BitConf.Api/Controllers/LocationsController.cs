using BitConf.IRepositories;
using BitConf.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitConf.Api.Controllers
{


    // extension to vs code: restclient

    /* locations.http
     
       PUT http://localhost:5000/api/locations HTTP/1.1
       Content-Type: application/json

       {
	    "VehicleId": "012",
	    "Latitude": 23.43,
	    "Longitude": 58.01
        }
     
     */









    [Route("api/{controller}")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationsController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Location location)
        {
            locationService.Add(location);
            return Ok();
        }

        [HttpGet("{vehicleId}")]
        public IActionResult Get(string vehicleId)
        {
            var location = locationService.Get(vehicleId);

            if (location == null)
                return NotFound();

            return Ok(location);
        }


         /* locations.http
     
       GET http://localhost:5000/api/locations?lat=23.44&lng=58.43 HTTP/1.1

    */

        // api/locations?lat=23.44&lng=58.43
        [HttpGet]
        public IActionResult Get([FromQuery] double lat, [FromQuery] double lng, [FromQuery] double distance = 1000)
        {
            Location location = new Location { Latitude = lat, Longitude = lng };
            var results = locationService.Get(location, distance);

            return Ok(results);
        }
    }
}
