using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQuery : IRequest<List<Booking>>
    {
        public GetAllBookingsQuery(string user)
        {
            User = user;
        }

        public string User { get; }
    }
}
