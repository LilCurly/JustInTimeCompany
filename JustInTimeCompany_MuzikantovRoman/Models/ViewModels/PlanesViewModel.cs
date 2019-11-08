using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustInTimeCompany_MuzikantovRoman.Models.ViewModels
{
    public class PlanesViewModel
    {
        public List<Plane> PlanesStateOk { get; set; }
        public List<Plane> PlanesStateGarage { get; set; }
    }
}
