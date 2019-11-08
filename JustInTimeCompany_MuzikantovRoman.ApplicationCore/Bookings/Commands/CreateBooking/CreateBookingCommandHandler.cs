using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, bool>
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IUserRepository _userRepo;
        private readonly IFlightRepository _flightRepo;
        public CreateBookingCommandHandler(IBookingRepository bookingRepo, IUserRepository userRepo, IFlightRepository flightRepo)
        {
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
            _flightRepo = flightRepo;
        }

        public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var connectedUser = _userRepo.FindByName(request.User).Result;
            var flight = _flightRepo.Get(request.FlightId).Result;
            if(connectedUser == null || flight == null)
            {
                // TODO : Exception
            }
            await _bookingRepo.Create(new Booking(){ User = connectedUser, Flight = flight, Date = DateTime.Now, Count = request.Count });
            return true;
        }
    }
}
