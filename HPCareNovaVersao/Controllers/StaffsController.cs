using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Entities;
using DataLayer.EntityFramework;
using BusinessLayer.Implementation;

namespace PresentationLayer.Controllers {
    public class StaffsController : Controller {
        private HPCareDBContext db = new HPCareDBContext();
        private impStaff impStaff;

        public StaffsController() {
            impStaff = new impStaff(db);
        }

        public ActionResult ListClinicInformation() {
            return PartialView();
        }

        public JsonResult GetStaffInformation() {
            Staff staff = db.Users.Find(1) as Staff; //current user id
            var list = from u in db.Users
                       from p in db.Users.OfType<Staff>()
                       where u.User_id == staff.User_id &&
                       u.User_id == p.User_id
                       select new {
                           u.Name,
                           u.Address,
                           u.Email,
                           u.gender,
                           u.MaritalStatus,
                           u.Telephone,
                           u.User_identification,
                           p.ProfessionalType
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListLabTecInformation() {
            return PartialView();
        }

        [HttpPost]
        public void SaveStaffInformations(List<Staff> staffInformations) {
            impStaff.saveStaffInformations(staffInformations);
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
