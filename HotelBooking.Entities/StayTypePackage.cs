using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
  public  class StayTypePackage
    {
        public int Id { get; set; }

        public int StayTypeId { get; set; }

        public StayType StayType { get; set; }
    }
}
