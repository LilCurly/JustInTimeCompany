using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Queries.GetAllPlanes
{
    public class GetAllPlanesQueryHandler : IRequestHandler<GetAllPlanesQuery, List<Plane>>
    {
        private readonly IPlaneRepository _repo;
        public GetAllPlanesQueryHandler(IPlaneRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<Plane>> Handle(GetAllPlanesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
