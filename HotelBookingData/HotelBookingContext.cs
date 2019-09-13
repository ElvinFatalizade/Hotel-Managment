using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HotelBooking.Entities;

namespace HotelBookingData
{
   public class HotelBookingContext:DbContext
    {
        public HotelBookingContext(): base("HotelBookingContext")
        {

        }
        public DbSet<Stay>Stays { get; set; }

        public DbSet <Booking> Bookings { get; set; }

        public DbSet <StayType> StayTypes { get; set; }

        public  DbSet<StayTypePackage> StayTypePackages { get; set; }
    }
}
