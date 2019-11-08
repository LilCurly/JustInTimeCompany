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
    public sealed class AirportRepository : IAirportRepository
    {
        private readonly JustInTimeCompanyDbContext _dbContext;

        public AirportRepository(JustInTimeCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Airport> Get(int id)
        {
            return await _dbContext.Airports.Where(a => a.AirportId == id).SingleAsync();
        }

        public async Task<List<Airport>> GetAll()
        {
            return await _dbContext.Airports.ToListAsync();
        }
    }
}
