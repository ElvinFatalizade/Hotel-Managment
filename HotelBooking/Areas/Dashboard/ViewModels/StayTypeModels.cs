using HotelBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelBooking.Areas.Dashboard.ViewModels
{
    public class StayTypeListingModels
    {
        public IEnumerable <StayType> StayTypes { get; set; }
        public string SerchTerm { get;  set; }
    }

   

    public class StayTypeActionModels
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }

}