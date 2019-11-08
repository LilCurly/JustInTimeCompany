using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Models.ViewModels
{
    public class FlightBoxViewModel
    {
        public Flight Flight { get; set; }
        public int FlightId { get; set; }
        public int RemainingSeats { get; set; }
        public string PlaneName { get; set; }
        public int PlaneCapacity { get; set; }
        public int PlaneSpeed { get; set; }
        public string PlaneMotor { get; set; }
    }
}
