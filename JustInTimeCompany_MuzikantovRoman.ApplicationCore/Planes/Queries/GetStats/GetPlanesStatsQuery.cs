using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Queries.GetStats
{
    public class GetPlanesStatsQuery : IRequest<Dictionary<Plane, double>>
    {
    }
}
