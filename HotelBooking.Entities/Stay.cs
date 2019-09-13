using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Entities
{
  public  class Stay
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public int StayTypePackageId { get; set; }

        public StayTypePackage StayTypePackage { get; set; }
    }
}
