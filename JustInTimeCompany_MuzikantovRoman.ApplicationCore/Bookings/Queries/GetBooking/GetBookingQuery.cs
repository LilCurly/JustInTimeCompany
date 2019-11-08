using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBooking
{
    public class GetBookingQuery : IRequest<Booking>
    {
        public GetBookingQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
