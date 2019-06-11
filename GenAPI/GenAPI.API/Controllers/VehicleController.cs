using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenAPI.Domain.Entities;
using GenAPI.DomainServices.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService _service) => vehicleService = _service;
        [HttpGet]
        public IActionResult Get()
        {
            var result = vehicleService.GetVehicles();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get(string code)
        {
            var result = vehicleService.GetVehicles(code);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] Vehicle vehicle)
        {          
            var result = vehicleService.Create(ref vehicle);
            return Ok(Json(vehicle));
        }
    }
}