using HotelBooking.Areas.Dashboard.ViewModels;
using HotelBooking.Entities;
using HotelBookingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Areas.Dashboard.Controllers
{
   

    public class StayTypeController : Controller
    {
       
        StayTypeService StayTypeService = new StayTypeService();
       
        public ActionResult Index(string serchTerm)
        {

            StayTypeListingModels model = new StayTypeListingModels();

            model.SerchTerm = serchTerm;

            model.StayTypes = StayTypeService.SearchStayType(serchTerm);

            return View(model);
            
        }

        [HttpGet]
        public ActionResult Action(int? Id)
        {
            StayTypeActionModels model = new StayTypeActionModels();

            if (Id.HasValue)
            {
                var staytype = StayTypeService.GetStayTypeById(Id.Value);
                model.Id = staytype.Id;
                model.Name = staytype.Name;
                model.Desc = staytype.Desc;
              
            }
           

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(StayTypeActionModels model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.Id > 0)
            {
                var staytype = StayTypeService.GetStayTypeById(model.Id);
                staytype.Name = model.Name;
                staytype.Desc = model.Desc;

                result = StayTypeService.UpdateStayType(staytype);
            }
            else
            {
                StayType stayType = new StayType();

                stayType.Name = model.Name;
                stayType.Desc = model.Desc;

                result = StayTypeService.SaveStayType(stayType);
            }
         

            if (result)
            {
                json.Data = new { Success = true };
            }
            else{
                json.Data = new { Success = false,  Message = "Xəta!" };
            }

            return json;
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            StayTypeActionModels model = new StayTypeActionModels();

            var staytype = StayTypeService.GetStayTypeById(Id);

            model.Id = staytype.Id;
           


            return PartialView("_Delete", model);
        }
        [HttpPost]
        public JsonResult Delete(StayTypeActionModels model)
        {
            JsonResult json = new JsonResult();
            var result = false;

            var staytype = StayTypeService.GetStayTypeById(model.Id);
           

            result = StayTypeService.DeleteStayType(staytype);


            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Xəta!" };
            }

            return json;
        }
    }
}