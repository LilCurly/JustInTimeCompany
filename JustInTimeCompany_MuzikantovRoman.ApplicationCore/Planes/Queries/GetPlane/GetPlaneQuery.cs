using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Queries.GetPlane
{
    public class GetPlaneQuery : IRequest<Plane>
    {
        public GetPlaneQuery(int planeId)
        {
            PlaneId = planeId;
        }

        public int PlaneId { get; }
    }
}
