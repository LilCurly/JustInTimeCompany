using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories
{
    public interface IPlaneRepository
    {
        Task<Plane> Get(int id);
        Task<List<Plane>> GetAll();
        Task<Dictionary<Plane, double>> GetPlanesStats();
        Task UpdateStatus(Plane plane);
    }
}
