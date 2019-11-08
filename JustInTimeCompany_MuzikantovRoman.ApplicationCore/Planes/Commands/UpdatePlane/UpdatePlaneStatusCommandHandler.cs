using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Commands.UpdatePlane
{
    public class UpdatePlaneStatusCommandHandler : IRequestHandler<UpdatePlaneStatusCommand, bool>
    {
        private readonly IPlaneRepository _repo;
        public UpdatePlaneStatusCommandHandler(IPlaneRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(UpdatePlaneStatusCommand request, CancellationToken cancellationToken)
        {
            var plane = _repo.Get(request.Id).Result;
            if(plane == null)
            {
                // THROW EXCEPTION
            }
            plane.CheckAndUpdateState();
            await _repo.UpdateStatus(plane);
            return true;
        }
    }
}
