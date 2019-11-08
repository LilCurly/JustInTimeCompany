using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.ApplicationCore.Planes.Commands.UpdatePlane
{
    public class UpdatePlaneToOkStatusCommand : IRequest<bool>
    {
        public UpdatePlaneToOkStatusCommand(int planeId)
        {
            PlaneId = planeId;
        }

        public int PlaneId { get; }
    }
}
