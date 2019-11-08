using JustInTimeCompany_MuzikantovRoman.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Models.CustomAttribute
{
    public class AnteriorToTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var form = (FlightFormViewModel) validationContext.ObjectInstance;

            if(form.DepartureDateTime < DateTime.Now)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return "La date de départ ne peut être antérieure à celle d'aujourd'hui !";
        }
    }
}
