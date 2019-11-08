using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<Booking>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IBookingRepository _bookingRepo;
        public GetAllBookingsQueryHandler(IUserRepository userRepo, IBookingRepository bookingRepo)
        {
            _userRepo = userRepo;
            _bookingRepo = bookingRepo;
        }
        public async Task<List<Booking>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var connectedUser = await _userRepo.FindByName(request.User);
            if(connectedUser == null)
            {
                // TODO : Exception
            }

            return await _bookingRepo.GetPerUser(connectedUser);
        }
    }
}
