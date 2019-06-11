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
    public class VehicleOrderServiceController : Controller
    {
        private readonly IVehicleOrderServiceService vehicleOrderServiceService;

        public VehicleOrderServiceController(IVehicleOrderServiceService _service) => vehicleOrderServiceService = _service;
        [HttpGet]
        public IActionResult Get()
        {
            var result = vehicleOrderServiceService.GetVehicleOrderServices();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get(string code)
        {
            var result = vehicleOrderServiceService.GetVehicleOrderServices(code);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] VehicleOrderService vehicleOrderService)
        {          
            var result = vehicleOrderServiceService.Create(ref vehicleOrderService);
            return Ok(Json(vehicleOrderService));
        }
    }
}