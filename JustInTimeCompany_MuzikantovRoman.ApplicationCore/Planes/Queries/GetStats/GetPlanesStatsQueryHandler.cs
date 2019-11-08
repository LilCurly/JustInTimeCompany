using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Queries.GetStats
{
    public class GetPlanesStatsQueryHandler : IRequestHandler<GetPlanesStatsQuery, Dictionary<Plane, double>>
    {
        private readonly IPlaneRepository _repo;

        public GetPlanesStatsQueryHandler(IPlaneRepository repo)
        {
            _repo = repo;
        }
        public async Task<Dictionary<Plane, double>> Handle(GetPlanesStatsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetPlanesStats();
        }
    }
}
