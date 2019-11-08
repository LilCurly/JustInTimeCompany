using JustInTimeCompany_MuzikantovRoman.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Commands.UpdatePlane
{
    public class UpdatePlaneStatusCommand : IRequest<bool>
    {
        public UpdatePlaneStatusCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
