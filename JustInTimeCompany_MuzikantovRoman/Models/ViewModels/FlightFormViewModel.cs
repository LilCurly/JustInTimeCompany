using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using JustInTimeCompany_MuzikantovRoman.Models.CustomAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Models.ViewModels
{
    public class FlightFormViewModel
    {
        // FLIGHT VALUES
        [Required(ErrorMessage = "Le champ Hélicoptère est obligatoire")]
        [Display(Name = "Hélicoptère")]
        public string Heli { get; set; }
        [Required(ErrorMessage = "Le champ Aéroport d'arrivée est obligatoire")]
        [AirportNotEquals]
        [Display(Name = "Aéroport d'arrivée")]
        public string ArrivalAirport { get; set; }
        [Required(ErrorMessage = "Le champ Aéroport de départ est obligatoire")]
        [AirportNotEquals]
        [Display(Name = "Aéroport de départ")]
        public string DepartureAirport { get; set; }
        [Required(ErrorMessage = "Le champ Date/Heure d'arrivée est obligatoire")]
        [StartAnteriorToEnd]
        [Display(Name = "Date/Heure d'arrivée")]
        public DateTime ArrivalDateTime { get; set; }
        [Required(ErrorMessage = "Le champ Date/Heure de départ est obligatoire")]
        [AnteriorToToday]
        [StartAnteriorToEnd]
        [Display(Name = "Date/Heure de départ")]
        public DateTime DepartureDateTime { get; set; }
        [Required(ErrorMessage = "Le champ Pilote est obligatoire")]
        [Display(Name = "Pilote")]
        public string Pilot { get; set; }
        [Required(ErrorMessage = "Le champ Nombre de places est obligatoire")]
        [Display(Name = "Nombre de places")]
        public string Seats { get; set; }

        // OPTIONS
        [Display(Name = "Répetition")]
        [Required(ErrorMessage = "Le champ Répetition est obligatoire")]
        public string Recurrence { get; set; }
        [Display(Name = "Nombre")]
        public string RecurrenceNbr { get; set; }
        public List<Plane> Planes { get; set; }
        public List<Airport> Airports { get; set; }

        public int FlightId { get; set; }
    }
}
