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
    public class FlightRepository : IFlightRepository
    {
        private readonly JustInTimeCompanyDbContext _dbContext;

        public FlightRepository(JustInTimeCompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Flight flight)
        {
            await _dbContext.Flights.AddAsync(flight);
            _dbContext.SaveChanges();
        }

        public async Task Delete(Flight flight)
        {
            _dbContext.Flights.Remove(flight);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Flight> Get(int id)
        {
            return await _dbContext.Flights
                .Where(f => f.FlightId == id)
                .Include(f => f.Bookings)
                .ThenInclude(b => b.User)
                .ThenInclude(u => u.Logs)
                .Include(f => f.Plane)
                .Include(f => f.Pilot)
                .Include(f => f.DepartureAirport)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.Logs)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Flight>> GetAll(int limit = 0)
        {
            var query = _dbContext.Flights
                .Include(f => f.Bookings)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Pilot)
                .Include(f => f.Plane)
                .OrderBy(f => f.DepartureTime)
                .AsQueryable();
            if(limit != 0)
            {
                query = query.Take(limit);
            }
            return await query.ToListAsync();
        }

        public async Task<int> GetFlightsCount(User pilot = null)
        {
            var query = _dbContext.Flights.AsQueryable();
            if(pilot != null)
            {
                query = query.Where(p => p.Pilot == pilot);
            }
            return await query.CountAsync();
        }

        public async Task<List<Flight>> GetIncomingFlights(int limit = 0)
        {
            var query = _dbContext.Flights
                .Include(f => f.Bookings)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Pilot)
                .Include(f => f.Plane)
                .Where(f => f.DepartureTime > DateTime.Now)
                .OrderBy(f => f.DepartureTime)
                .AsQueryable();
            if(limit != 0)
            {
                query = query.Take(limit);
            }
            return await query.ToListAsync();
        }

        public async Task<int> GetIncomingFlightsCount(User pilot = null)
        {
            var query = _dbContext.Flights.Where(p => p.DepartureTime > DateTime.Now).AsQueryable();
            if(pilot != null)
            {
                query = query.Where(p => p.Pilot == pilot);
            }
            return await query.CountAsync();
        }

        public async Task<List<Flight>> GetLate()
        {
            return await _dbContext.Flights.Where(f => f.LateReason != null).OrderBy(f => f.DepartureTime).ToListAsync();
        }

        public async Task<List<Flight>> GetPerAirport(Airport departureAirport, Airport arrivalAirport, DateTime? arrivalDateTime)
        {
            IQueryable<Flight> query = _dbContext.Flights.AsQueryable();
            if(departureAirport != null)
            {
                query = query.Where(f => f.DepartureAirport == departureAirport);
            }
            if(arrivalAirport != null)
            {
                query = query.Where(f => f.ArrivalAirport == arrivalAirport);
            }
            if(arrivalDateTime.HasValue)
            {
                DateTime arrivalDate = arrivalDateTime.Value;
                query = query.Where(f => f.ArrivalTime.Year == arrivalDate.Year 
                && f.ArrivalTime.Month == arrivalDate.Month 
                && f.ArrivalTime.Day == arrivalDate.Day);
            }

            return await query.Include(f => f.Bookings).OrderBy(f => f.DepartureTime).ToListAsync();
        }

        public async Task<List<Flight>> GetPerPilot(User pilot, int limit = 0)
        {
            var query = _dbContext.Flights
                .Include(f => f.Bookings)
                .Include(f => f.ArrivalAirport)
                .Include(f => f.DepartureAirport)
                .Include(f => f.Pilot)
                .Include(f => f.Plane)
                .Where(f => f.Pilot == pilot)
                .OrderBy(f => f.DepartureTime)
                .AsQueryable();
            if(limit != 0)
            {
                query = query.Take(limit);
            }
            return await query.ToListAsync();
        }

        public List<User> GetUsersInFlight(Flight flight)
        {
            return flight.Bookings.Select(b => b.User).ToList();
        }

        public async Task Update(Flight flight)
        {
            _dbContext.Flights.Update(flight);
            await _dbContext.SaveChangesAsync();
        }
    }
}
