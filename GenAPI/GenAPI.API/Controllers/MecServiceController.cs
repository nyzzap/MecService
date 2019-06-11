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
    public class MecServiceController : Controller
    {
        private readonly IMecServiceService mecServiceService;

        public MecServiceController(IMecServiceService _service) => mecServiceService = _service;
        [HttpGet]
        public IActionResult Get()
        {
            var result = mecServiceService.GetMecServices();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get(string code)
        {
            var result = mecServiceService.GetMecServices(code);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] MecService mecService)
        {          
            var result = mecServiceService.Create(ref mecService);
            return Ok(Json(mecService));
        }
    }
}