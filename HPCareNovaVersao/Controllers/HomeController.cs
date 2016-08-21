using BusinessLayer;
using BusinessLayer.Implementation;
using DataLayer.Entities;
using DataLayer.EntityFramework;
using HPCareNovaVersao;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers {
    public class HomeController : Controller {

        HPCareDBContext context = new HPCareDBContext();

        public ActionResult Index() {
            if(User.IsInRole("Admin")) {
                return RedirectToAction("DashboardAdmin", "Home/");
            } else if(User.IsInRole("Clinic")) {
                return Redirect("Hpcare/Home.html");
                //  return RedirectToAction("DashboardClinic2", "Home/");
            } else if(User.IsInRole("LabTec")) {
                return Redirect("Hpcare/HomeLabTec.html");
            } else if(User.IsInRole("Patient")) {
                return RedirectToAction("DashboardPatient", "Home/");
            }


            //Patient p = new Patient { User_id = 2 };
            //Staff s = new Staff { User_id = 1 };
            //int aux = SingletonClinicRegistry.GetInstance(p, s, context).ClinicRegistryManagerId;
            //int aux3 = SingletonClinicRegistry.GetInstance(p, s, context).ClinicRegistryManagerId;
            //int aux4 = aux3 + 2;
            return View();

        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }

        public ActionResult Users() {
            HPCareDBContext context = new HPCareDBContext();

            var users = context.Users.ToList();
            ViewBag.users = users;
            return View();
        }

        public ActionResult DashboardAdmin() {
            return View();
        }

        public ActionResult DashboardClinic() {
            return View();
        }

        public ActionResult DashboardLabTec() {
            CurrentUserId user = new CurrentUserId();
            ViewBag.aux = user.AccessDatabase(User.Identity.GetUserName());

            return View();
        }

        public ActionResult DashboardPatient() {
            return View();
        }

        public ActionResult Success() {
            return View();
        }

        public ActionResult DashboardClinic2() {
            //CurrentUserId user = new CurrentUserId();
            //ViewBag.aux = user.AccessDatabase(User.Identity.GetUserName());

            return View();
        }

        public ActionResult SearchPatient(string search) {
            PatientId(search);
            return PartialView();
        }

        public Users PatientId(string search) {
            ImpHome homeImplementation = new ImpHome();
            string aux = Request.QueryString["search"];
            //string aux = "4_2";
            Users patient = homeImplementation.AccessDatabase(aux);
            Session["patientId"] = patient.User_id;

            return patient;
        }

    }
}