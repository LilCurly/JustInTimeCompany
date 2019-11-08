using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Airports.Queries;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Commands.CreateBooking;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.CreateFlight;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.DeleteFlight;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.UpdateFlight;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetAllFlights;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlight;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Queries.GetAllPlanes;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Queries.GetPlane;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetPilots;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetUser;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using JustInTimeCompany_MuzikantovRoman.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany_MuzikantovRoman.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Show()
        {
            var flights = await _mediator.Send(new GetAllFlightsQuery());
            FlightShowViewModel vm = new FlightShowViewModel()
            {
                Flights = await _mediator.Send(new GetAllFlightsQuery()),
                Airports = await _mediator.Send(new GetAllAirportQuery())
            };
            return View(vm);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Book(int flightId, int count)
        {
            var flight = await _mediator.Send(new GetFlightQuery(flightId));
            if (flight.CanBeCanceledOrModified())
            {
                var user = User.Identity.Name;
                await _mediator.Send(new CreateBookingCommand(user, flightId, count));

                return RedirectToAction("Show", "Bookings");
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(DateTime from, DateTime to, string comment, int flightId)
        {
            var flight = await _mediator.Send(new GetFlightQuery(flightId));

            if (flight.CanBeConfirmed())
            {
                await _mediator.Send(new UpdateFlightRealTimeCommand(flightId, from, to, comment));
            }
            return RedirectToAction("Show");
        }

        public async Task<IActionResult> Create()
        {
            FlightFormViewModel vm = new FlightFormViewModel
            {
                Airports = await _mediator.Send(new GetAllAirportQuery()),
                Planes = await _mediator.Send(new GetAllPlanesQuery())
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string heli, string arrivalAirport, string departureAirport, DateTime arrivalDateTime, 
            DateTime departureDateTime, string pilot, string seats, string recurrence, string recurrenceNbr)
        {
            FlightFormViewModel vm = new FlightFormViewModel
            {
                Airports = await _mediator.Send(new GetAllAirportQuery()),
                Planes = await _mediator.Send(new GetAllPlanesQuery()),
                Heli = heli,
                ArrivalAirport = arrivalAirport,
                DepartureAirport = departureAirport,
                ArrivalDateTime = arrivalDateTime,
                DepartureDateTime = departureDateTime,
                Pilot = pilot,
                Seats = seats,
                Recurrence = recurrence,
                RecurrenceNbr = recurrenceNbr
            };

            if(ModelState.IsValid)
            {
                var flight = new Flight()
                {
                    DepartureTime = departureDateTime,
                    ArrivalTime = arrivalDateTime,
                    DepartureAirport = await _mediator.Send(new GetAirportQuery(int.Parse(departureAirport))),
                    ArrivalAirport = await _mediator.Send(new GetAirportQuery(int.Parse(arrivalAirport))),
                    Plane = await _mediator.Send(new GetPlaneQuery(int.Parse(heli))),
                    Pilot = await _mediator.Send(new GetUserByIdQuery(int.Parse(pilot))),
                    Seats = int.Parse(seats)
                };
                if(recurrence == "onetime")
                {
                    await _mediator.Send(new CreateFlightCommand(flight));
                }
                else if(recurrence == "everyday")
                {
                    await _mediator.Send(new CreateFlightEveryDayOfWeekCommand(departureDateTime, arrivalDateTime, int.Parse(heli), int.Parse(pilot), int.Parse(departureAirport), int.Parse(arrivalAirport), int.Parse(seats)));
                }
                else
                {
                    await _mediator.Send(new CreateFlightEveryWeekCommand(departureDateTime, arrivalDateTime, int.Parse(heli), int.Parse(pilot), int.Parse(departureAirport), int.Parse(arrivalAirport), int.Parse(seats), int.Parse(recurrenceNbr)));
                }
                return RedirectToAction("Show");
            }

            return View(vm);
        }

        public async Task<JsonResult> FilterPilots(string from, string to)
        {
            DateTime _from = DateTime.ParseExact(from, "dd/MM/yyyy HH:mm", null);
            DateTime _to = DateTime.ParseExact(to, "dd/MM/yyyy HH:mm", null);
            return new JsonResult(await _mediator.Send(new GetAvailablePilotsQuery(_from, _to)));
        }

        public async Task<JsonResult> FilterPilotsModify(string from, string to, int flightId)
        {
            DateTime _from = DateTime.ParseExact(from, "dd/MM/yyyy HH:mm", null);
            DateTime _to = DateTime.ParseExact(to, "dd/MM/yyyy HH:mm", null);
            return new JsonResult(await _mediator.Send(new GetAvailablePilotsQuery(_from, _to, flightId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int flightId)
        {
            var flight = await _mediator.Send(new GetFlightQuery(flightId));

            if(flight.CanBeCanceledOrModified())
            {
                await _mediator.Send(new DeleteFlightCommand(flightId));

                return RedirectToAction("Show");
            }

            return NotFound();
        }

        public async Task<IActionResult> Modify(int id)
        {
            var flight = await _mediator.Send(new GetFlightQuery(id));

            if(flight.CanBeCanceledOrModified())
            {
                FlightFormViewModel vm = new FlightFormViewModel
                {
                    Airports = await _mediator.Send(new GetAllAirportQuery()),
                    Planes = await _mediator.Send(new GetAllPlanesQuery()),
                    Heli = flight.Plane.PlaneId.ToString(),
                    ArrivalAirport = flight.ArrivalAirport.AirportId.ToString(),
                    DepartureAirport = flight.DepartureAirport.AirportId.ToString(),
                    ArrivalDateTime = flight.ArrivalTime,
                    DepartureDateTime = flight.DepartureTime,
                    Pilot = flight.Pilot.UserId.ToString(),
                    Seats = flight.Seats.ToString(),
                    FlightId = id
                };

                return View(vm);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(string heli, string arrivalAirport, string departureAirport, DateTime arrivalDateTime, 
            DateTime departureDateTime, string pilot, string seats, int flightId)
        {
            FlightFormViewModel vm = new FlightFormViewModel
            {
                Airports = await _mediator.Send(new GetAllAirportQuery()),
                Planes = await _mediator.Send(new GetAllPlanesQuery()),
                Heli = heli,
                ArrivalAirport = arrivalAirport,
                DepartureAirport = departureAirport,
                ArrivalDateTime = arrivalDateTime,
                DepartureDateTime = departureDateTime,
                Pilot = pilot,
                Seats = seats,
                FlightId = flightId
            };

            if(ModelState.IsValid)
            {
                var planeObj = await _mediator.Send(new GetPlaneQuery(int.Parse(heli)));
                var pilotObj = await _mediator.Send(new GetUserByIdQuery(int.Parse(pilot)));
                var departureAirportObj = await _mediator.Send(new GetAirportQuery(int.Parse(departureAirport)));
                var arrivalAirportObj = await _mediator.Send(new GetAirportQuery(int.Parse(arrivalAirport)));

                await _mediator.Send(new UpdateFlightCommand(flightId, departureDateTime, arrivalDateTime, planeObj, pilotObj, departureAirportObj, arrivalAirportObj, int.Parse(seats)));
                
                return RedirectToAction("Show");
            }

            return View(vm);
        }
    }
}