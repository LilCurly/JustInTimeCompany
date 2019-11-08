using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Models.ViewModels
{
    public class MemberSummaryViewModel
    {
        public List<Booking> IncomingBookings { get; set; }
        public int IncomingBookingsCount { get; set; }
        public int TotalBookingsCount { get; set; }
        public List<Flight> NextFlights { get; set; }
        public List<string> Logs { get; set; }

        // Pilot
        public List<Flight> NextFlightsToDo { get; set; }
        public int TotalFlightsDoneCount { get; set; }
        public int FlightsToDoCount { get; set; }

        // Director
        public int TotalFlightsCount { get; set; }
        public int TotalIncomingFlightsCount { get; set; }
    }
}
