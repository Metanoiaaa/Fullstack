using Fullstack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fullstack.Controllers
{
    [Route("")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet("status")] 
        public String status()
        {
            return "OK";
        }

        [HttpGet("WhatIsGroot")]
        public Plantje MaakPlantje()
        { 
            Plantje p = new Plantje();
            p.Id = 1;
            p.Name = "groot";
            p.Age = 30;
            return p;

        }

    }
}
