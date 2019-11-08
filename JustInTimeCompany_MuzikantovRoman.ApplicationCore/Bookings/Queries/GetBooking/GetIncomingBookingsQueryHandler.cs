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
    public class GetIncomingBookingsQueryHandler : IRequestHandler<GetIncomingBookingsQuery, List<Booking>>
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IUserRepository _userRepo;

        public GetIncomingBookingsQueryHandler(IBookingRepository bookingRepo, IUserRepository userRepo)
        {
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
        }

        public async Task<List<Booking>> Handle(GetIncomingBookingsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.FindByName(request.User);
            if (user == null)
            {
                // THROW EXCEPTION
            }
            return await _bookingRepo.GetPerUserIncoming(user, 3);
        }
    }
}
