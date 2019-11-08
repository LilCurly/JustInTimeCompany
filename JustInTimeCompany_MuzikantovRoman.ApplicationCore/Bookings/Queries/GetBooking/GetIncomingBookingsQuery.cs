using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBooking
{
    public class GetIncomingBookingsQuery : IRequest<List<Booking>>
    {
        public GetIncomingBookingsQuery(string user)
        {
            User = user;
        }

        public string User { get; }
    }
}
