using BusinessLayer.Implementation;
using DataLayer.Entities;
using DataLayer.Entities.DiagnosisEntities;
using DataLayer.Entities.Visitas;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer {
    public class SingletonClinicRegistry {
        private static ClinicRegistryManager singletonInstance;
        private SingletonClinicRegistry() {

        }
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static ClinicRegistryManager GetInstance(HPCareDBContext context) {
            Patient patient = context.Users.Find(HttpContext.Current.Session["patientId"]) as Patient;
            //get information about the current clinic logged in
            CurrentUserId currentStaff = new CurrentUserId();
            int currentIdStaff = currentStaff.AccessDatabase(HttpContext.Current.User.Identity.Name);
            //Users staff = currentStaff.ReturnCurrentUser(currentIdStaff);
            Staff staff = context.Users.Find(currentIdStaff) as Staff;
            if (singletonInstance == null) {
                // singletonInstance = new ClinicRegistryManager { ClinicRegistryManagerId = AccessDatabase(patient, staff, context).ClinicRegistryManagerId };
                singletonInstance = new ClinicRegistryManager { Clinic_patient = patient, Staff_doctor = staff };
                Visit visit = new Visit { Visit_Date = DateTime.Today.Date, Visit_Hour = DateTime.Now.TimeOfDay };
                context.VisitManagers.Add(new VisitManager { visit = visit, PatientVisitRegistry = singletonInstance });
                context.SaveChanges();
            }

            return context.ClinicRegistryManagers.Find(singletonInstance.ClinicRegistryManagerId);
        }

    }
}