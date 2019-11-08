using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Queries.GetPlane
{
    class GetPlaneQueryHandler : IRequestHandler<GetPlaneQuery ,Plane>
    {
        private readonly IPlaneRepository _repo;

        public GetPlaneQueryHandler(IPlaneRepository repo)
        {
            _repo = repo;
        }

        public async Task<Plane> Handle(GetPlaneQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.PlaneId);
        }
    }
}
