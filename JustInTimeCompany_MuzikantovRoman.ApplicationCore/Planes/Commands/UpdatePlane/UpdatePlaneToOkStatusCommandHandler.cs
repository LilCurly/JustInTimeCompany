using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Commands.UpdatePlane
{
    public class UpdatePlaneToOkStatusCommandHandler : IRequestHandler<UpdatePlaneToOkStatusCommand, bool>
    {
        private readonly IPlaneRepository _repo;

        public UpdatePlaneToOkStatusCommandHandler(IPlaneRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(UpdatePlaneToOkStatusCommand request, CancellationToken cancellationToken)
        {
            var plane = _repo.Get(request.PlaneId).Result;
            plane.UpdateStateToOk();
            await _repo.UpdateStatus(plane);
            return true;
        }
    }
}
