using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Models.ViewModels
{
    public class FlightShowViewModel
    {
        public List<Flight> Flights { get; set; }
        public List<Airport> Airports { get; set; }
    }
}
