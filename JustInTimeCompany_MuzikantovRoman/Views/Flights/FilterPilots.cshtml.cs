using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Interfaces.Gateways.Repositories;
using JustInTimeCompany_MuzikantovRoman.ApplicationCore.Users.Queries.GetPilots;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustInTimeCompany_MuzikantovRoman.Views.Flights
{
    public class FilterPilotsModel : PageModel
    {
        private readonly IMediator _mediator;

        public FilterPilotsModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public JsonResult OnGet(string from, string to)
        {
            DateTime _from = DateTime.ParseExact(from, "dd/MM/yyyy HH:mm", null);
            DateTime _to = DateTime.ParseExact(to, "dd/MM/yyyy HH:mm", null);
            var a = new JsonResult(_mediator.Send(new GetAvailablePilotsQuery(_from, _to)));
            return new JsonResult(_mediator.Send(new GetAvailablePilotsQuery(_from, _to)));
        }
    }
}