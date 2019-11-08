using System;
using System.Collections.Generic;
using System.Text;

namespace JustInTimeCompany_MuzikantovRoman.Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Flight Flight { get; set; }

        public bool CanBeCanceled()
        {
            if(Flight.DepartureTime.AddDays(-1) > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public string DateFormat(DateTime date)
        {
            return date.ToString("MM/dd/yyyy");
        }

        public string TimeFormat(DateTime date)
        {
            return date.ToString("HH:mm");
        }
    }
}
