using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, Booking>
    {
        private readonly IBookingRepository _repo;
        public GetBookingQueryHandler(IBookingRepository repo)
        {
            _repo = repo;
        }

        public async Task<Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.Id);
        }
    }
}
