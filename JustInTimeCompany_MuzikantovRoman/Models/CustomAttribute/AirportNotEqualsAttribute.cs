using JustInTimeCompany_MuzikantovRoman.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Models.CustomAttribute
{
    public class AirportNotEqualsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var form = (FlightFormViewModel) validationContext.ObjectInstance;

            if(form.ArrivalAirport == form.DepartureAirport)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return "L'aéroport de départ ne peut être le même que l'aéroport d'arrivé";
        }
    }
}
