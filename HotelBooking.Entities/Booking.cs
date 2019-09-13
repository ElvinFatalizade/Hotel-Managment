using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
   public class Booking
    {
        public int Id { get; set; }

        public int StayId  { get; set; }

        public Stay Stay { get; set; }

        public DateTime  FromDate { get; set; }

        public int Duration { get; set; }
    }
}
