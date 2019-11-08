using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Domain.Entities
{
    public enum Recurrence
    {
        None,
        EveryDay,
        EveryWeek
    }

    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime RealDepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime RealArrivalTime { get; set; }
        public Plane Plane { get; set; }
        public User Pilot { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public int Seats { get; set; }
        public string LateReason { get; set; }
        public bool IsConfirmed { get; set; }

         public int RemainingSeats { 
            get 
            {
                int result = Seats;
                foreach(Booking booking in Bookings)
                {
                    result -= booking.Count;
                }
                return result;
            }
        }

        public int SeatsTaken {
            get 
            {
                return Seats - RemainingSeats;
            }
        }

        public ICollection<Log> Logs { get; set; }

        public string ToLog()
        {
            return $"From : {DepartureAirport} AT {DepartureTime} ; To : {ArrivalAirport} AT {ArrivalTime} ; Plane : {Plane} ; Pilot : {Pilot} ; Seats : {Seats}";
        }

        public string ToUserLog(DateTime newDeparture, DateTime newArrival)
        {
            return $"L'horaire du vol #{FlightId} à départ de {DepartureAirport.Name} a été modifié : départ à {newDeparture.ToString()} (anciennement : {DepartureTime}), arrivé à {newArrival.ToString()} (anciennement : {ArrivalTime})";
        }

        public bool CanBeCanceledOrModified()
        {
            return DepartureTime > DateTime.Now;
        }

        public bool CanBeConfirmed()
        {
            return DepartureTime < DateTime.Now;
        }
    }
}
