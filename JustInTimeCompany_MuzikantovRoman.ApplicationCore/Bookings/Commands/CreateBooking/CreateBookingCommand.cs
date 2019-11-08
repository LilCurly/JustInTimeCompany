using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<bool>
    {
        public CreateBookingCommand(string user, int flightId, int count)
        {
            User = user;
            FlightId = flightId;
            Count = count;
        }

        public string User { get; }
        public int FlightId { get; }
        public int Count { get; }
    }
}
