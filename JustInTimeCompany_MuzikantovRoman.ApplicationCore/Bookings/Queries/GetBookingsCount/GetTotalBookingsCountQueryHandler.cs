using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Queries.GetBookingsCount
{
    class GetTotalBookingsCountQueryHandler : IRequestHandler<GetTotalBookingsCountQuery, int>
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IUserRepository _userRepo;

        public GetTotalBookingsCountQueryHandler(IBookingRepository bookingRepo, IUserRepository userRepo)
        {
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
        }

        public async Task<int> Handle(GetTotalBookingsCountQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepo.FindByName(request.User).Result;
            if(user == null)
            {
                //THROW EXCEPTION
            }
            return await _bookingRepo.GetTotalCount(user);
        }
    }
}
