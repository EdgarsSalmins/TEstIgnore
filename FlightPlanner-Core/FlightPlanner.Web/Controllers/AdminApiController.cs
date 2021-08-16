using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Web.Models.Requests;

namespace FlightPlanner.Web.Controllers
{
    [Route("admin-api")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public AdminApiController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [Route("flights/{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightService.GetById(id);
            if(flight != null)
                return Ok(flight);
            return NotFound();
        }

        [HttpPut, Route("flights")]
        public IActionResult PutFlights(AddFlightRequest request)
        {
            if (!ValidateFlight(request))
                return BadRequest();
            var flight = new Flight
            {
                ArrivalTime = DateTime.Parse(request.ArrivalTime),
                Carrier = request.Carrier,
                DepartureTime = DateTime.Parse(request.DepartureTime),
                From = request.From,
                To = request.To
            };

            var result = _flightService.Create(flight);
            if (result.Succeeded) { 
                flight.Id = result.Entity.Id;
                return Created("", flight);
            }

            return BadRequest();
        }

        private bool ValidateFlight(AddFlightRequest request)
        {
            if (string.IsNullOrEmpty(request.ArrivalTime))
                return false;
            if (string.IsNullOrEmpty(request.DepartureTime))
                return false;
            var arrivalDate = DateTime.Parse(request.ArrivalTime);
            var departureDate = DateTime.Parse(request.DepartureTime);
            if (arrivalDate <= departureDate)
                return false;
            if (string.IsNullOrEmpty(request.From?.City) ||
                string.IsNullOrEmpty(request.From?.Country) ||
                string.IsNullOrEmpty(request.From?.AirportCode))
                return false;
            if (string.IsNullOrEmpty(request.To?.City) ||
                string.IsNullOrEmpty(request.To?.Country) ||
                string.IsNullOrEmpty(request.To?.AirportCode))
                return false;
            if (request.To?.AirportCode.Trim().ToLowerInvariant() == request.From?.AirportCode.Trim().ToLowerInvariant())
                return false;
            if (string.IsNullOrEmpty(request.Carrier))
                return false;
            return true;
        }
    }
}
