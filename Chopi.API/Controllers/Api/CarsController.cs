﻿using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerWithSIgnalR<CarHub, ICarHubActions, CarData>
    {
        private readonly IUnitOfCars _unit;

        public CarsController(IUnitOfCars unit, IHubContext<CarHub, ICarHubActions> hub) : base(hub)
        {
            _unit = unit;
        }

        [HttpGet("customcars")]
        public IActionResult GetCustomCars()
        {
            return Ok(_unit.CustomCar.GetAll());
        }

        [HttpGet("completecars")]
        public IActionResult GetCompleteCars()
        {
            return Ok(_unit.CompleteCar.GetAll());
        }
    }
}
