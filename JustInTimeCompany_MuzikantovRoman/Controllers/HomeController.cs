using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBooking;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBookingsCount;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlight;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Queries.GetFlightCount;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetLogs;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using JustInTimeCompany_MuzikantovRoman.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany_MuzikantovRoman.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                var userName = HttpContext.User.Identity.Name;
                MemberSummaryViewModel vm = new MemberSummaryViewModel
                {
                    IncomingBookings = await _mediator.Send(new GetIncomingBookingsQuery(userName)),
                    IncomingBookingsCount = await _mediator.Send(new GetIncomingBookingsCountQuery(userName)),
                    TotalBookingsCount = await _mediator.Send(new GetTotalBookingsCountQuery(userName)),
                    NextFlights = await _mediator.Send(new GetIncomingFlightsQuery()),
                    Logs = await _mediator.Send(new GetUserLogsQuery(userName))
                };
                if(User.IsInRole("Pilot"))
                {
                    vm.NextFlightsToDo = await _mediator.Send(new GetFlightsPerPilotQuery(userName, 3));
                    vm.TotalFlightsDoneCount = await _mediator.Send(new GetTotalFlightsCountQuery(userName));
                    vm.FlightsToDoCount = await _mediator.Send(new GetIncomingFlightsCountQuery(userName));
                }
                if(User.IsInRole("Director"))
                {
                    vm.TotalFlightsCount = await _mediator.Send(new GetTotalFlightsCountQuery());
                    vm.TotalIncomingFlightsCount = await _mediator.Send(new GetIncomingFlightsCountQuery());
                }

                return View(vm);
            }
            return View();
        }
    }
}