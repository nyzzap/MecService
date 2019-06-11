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
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService _service) => clientService = _service;
        [HttpGet]
        public IActionResult Get()
        {
            var result = clientService.GetClients();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get(string code)
        {
            var result = clientService.GetClientByCode(code);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Insert([FromBody] Client client)
        {          
            var result = clientService.Create(ref client);
            return Ok(Json(client));
        }
    }
}