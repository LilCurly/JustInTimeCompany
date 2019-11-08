using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Flights.Commands.DeleteFlight
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, bool>
    {
        private readonly IFlightRepository _repo;
        public DeleteFlightCommandHandler(IFlightRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = _repo.Get(request.Id).Result;
            if(flight == null)
            {
                // TODO : Exception
            }
            await _repo.Delete(flight);
            return true;
        }
    }
}
