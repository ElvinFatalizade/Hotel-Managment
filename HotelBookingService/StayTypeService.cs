using HotelBooking.Entities;
using HotelBookingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingService
{
  public  class StayTypeService
    {
        public IEnumerable<StayType> GetAllStayType()
        {
            var context = new HotelBookingContext();

            return context.StayTypes.ToList();
        }

        public IEnumerable<StayType> SearchStayType(string serchTerm)
        {
            var context = new HotelBookingContext();

            var stayType = context.StayTypes.AsQueryable();

            if (!string.IsNullOrEmpty(serchTerm))
            {
               stayType= stayType.Where(s => s.Name.ToLower().Contains(serchTerm.ToLower()));
            }

            return stayType.ToList();
        }

        public StayType GetStayTypeById(int Id)
        {
            var context = new HotelBookingContext();

            return context.StayTypes.Find(Id);
        }

        public bool SaveStayType(StayType stayType)
        {
            var context = new HotelBookingContext();

            context.StayTypes.Add(stayType);

           return  context.SaveChanges() > 0 ;
        }

        public bool UpdateStayType(StayType stayType)
        {
            var context = new HotelBookingContext();

            context.Entry(stayType).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteStayType(StayType stayType)
        {
            var context = new HotelBookingContext();

            context.Entry(stayType).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
