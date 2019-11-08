using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Flight> PilotFlights { get; set; }
        public ICollection<LogUser> Logs { get; set; }
        public bool IsPilot { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public bool IsAvailable(DateTime from, DateTime to)
        {
            var result = true;
            foreach(Flight flight in PilotFlights)
            {
                if(from <= flight.ArrivalTime && to >= flight.DepartureTime)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
