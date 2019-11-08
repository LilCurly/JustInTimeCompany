using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Domain.Entities
{
    public enum State
    {
        Ok,
        Garage
    }
    public class Plane
    {
        public int PlaneId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }
        public string Motor { get; set; }
        public int TimesUsed { get; set; }
        public State State { get; set; }

        public void CheckAndUpdateState()
        {
            if(State == State.Ok && TimesUsed == 6)
            {
                State = State.Garage;
            }
        }

        public void UpdateStateToOk()
        {
            State = State.Ok;
            TimesUsed = 0;
        }

        public bool IsInGararge()
        {
            return State == State.Garage ? true : false;
        }
    }
}
