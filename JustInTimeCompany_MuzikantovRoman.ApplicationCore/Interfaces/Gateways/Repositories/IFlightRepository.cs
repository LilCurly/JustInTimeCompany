using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories
{
    public interface IFlightRepository
    {
        Task Create(Flight flight);
        Task Update(Flight flight);
        Task Delete(Flight flight);
        Task<Flight> Get(int id);
        Task<List<Flight>> GetAll(int limit = 0);
        Task<List<Flight>> GetPerPilot(User pilot, int limit = 0);
        Task<List<Flight>> GetPerAirport(Airport departureAirport, Airport arrivalAirport, DateTime? arrivalDateTime);
        Task<List<Flight>> GetLate();
        Task<List<Flight>> GetIncomingFlights(int limit = 0);
        Task<int> GetFlightsCount(User pilot = null);
        Task<int> GetIncomingFlightsCount(User pilot = null);
        List<User> GetUsersInFlight(Flight flight);
    }
}
