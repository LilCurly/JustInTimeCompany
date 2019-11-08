using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Commands.DeleteBooking;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetAllBookings;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JustInTimeCompany_MuzikantovRoman.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Show()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery(User.Identity.Name)); 
            return View(bookings);
        }

        public ActionResult Filtrate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cancel(int bookingId)
        {
            var booking = await _mediator.Send(new GetBookingQuery(bookingId));
            if(booking != null && booking.CanBeCanceled())
            {
                await _mediator.Send(new DeleteBookingCommand(bookingId));
                return RedirectToAction("Show");
            }
            return NotFound();
        }
    }
}