using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, bool>
    {
        private readonly IBookingRepository _repo;
        public DeleteBookingCommandHandler(IBookingRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = _repo.Get(request.Id).Result;
            if(booking == null)
            {
                // TODO : Excpetion
            }
            if (booking.CanBeCanceled())
            {
                await _repo.Delete(booking);
            }
            return true;
        }
    }
}
