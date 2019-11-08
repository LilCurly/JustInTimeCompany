using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly JustInTimeCompanyDbContext _dbContext;

        public PlaneRepository(JustInTimeCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Plane> Get(int id)
        {
            return await _dbContext.Planes.Where(p => p.PlaneId == id).SingleOrDefaultAsync();
        }

        public async Task<List<Plane>> GetAll()
        {
            return await _dbContext.Planes.ToListAsync();
        }

        public async Task<Dictionary<Plane, double>> GetPlanesStats()
        {
            return await _dbContext.Flights
                .Include(f => f.Bookings)
                .Include(f => f.Plane)
                .GroupBy(f => f.Plane)
                .Select(g => new { Key = g.Key, Value = g.Sum(i => (double) ((i.Seats - i.RemainingSeats) / i.Plane.Capacity) / g.Count()) })
                .ToDictionaryAsync(x => x.Key, x => x.Value);
        }

        public async Task UpdateStatus(Plane plane)
        {
            _dbContext.Planes.Update(plane);
            await _dbContext.SaveChangesAsync();
        }
    }
}
