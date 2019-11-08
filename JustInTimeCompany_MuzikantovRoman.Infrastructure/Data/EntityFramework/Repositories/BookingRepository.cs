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
    public class BookingRepository : IBookingRepository
    {
        private readonly JustInTimeCompanyDbContext _dbContext;

        public BookingRepository(JustInTimeCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Booking booking)
        {
            await _dbContext.Bookings.AddAsync(booking);
            _dbContext.SaveChanges();
        }

        public async Task Delete(Booking booking)
        {
            _dbContext.Bookings.Remove(booking);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Booking> Get(int id)
        {
            return await _dbContext.Bookings.Where(b => b.BookingId == id).Include(b => b.Flight).ThenInclude(f => f.Plane).FirstOrDefaultAsync();
        }

        public async Task<int> GetIncomingCount(User user)
        {
            return await _dbContext.Bookings.Include(b => b.Flight).Where(b => b.User == user && b.Flight.DepartureTime > DateTime.Now).CountAsync();
        }

        public async Task<List<Booking>> GetPerUser(User user, int limit = 0)
        {
            var query = _dbContext.Bookings
                .Where(b => b.User == user)
                .Include(b => b.Flight)
                .ThenInclude(f => f.Plane)
                .Include(b => b.Flight)
                .ThenInclude(f => f.DepartureAirport)
                .Include(b => b.Flight)
                .ThenInclude(f => f.ArrivalAirport)
                .OrderBy(d => d.Date)
                .AsQueryable();
            if(limit != 0)
            {
                query = query.Take(limit);
            }
            return await query.ToListAsync();
        }

        public async Task<List<Booking>> GetPerUserIncoming(User user, int limit = 0)
        {
            var query = _dbContext.Bookings.Include(b => b.Flight).ThenInclude(f => f.Plane).Where(b => b.User == user && b.Flight.DepartureTime > DateTime.Now).OrderBy(d => d.Date).AsQueryable();
            if(limit != 0)
            {
                query = query.Take(limit);
            }
            return await query.ToListAsync();
        }

        public async Task<int> GetTotalCount(User user)
        {
            return await _dbContext.Bookings.Include(b => b.Flight).Where(b => b.User == user).CountAsync();
        }
    }
}
