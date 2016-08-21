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

        public static ClinicRegistryManager GetInstance(HPCareDBContext context) {
            Patient patient = context.Users.Find(HttpContext.Current.Session["patientId"]) as Patient;
            //get information about the current clinic logged in
            CurrentUserId currentStaff = new CurrentUserId();
            int currentIdStaff = currentStaff.AccessDatabase(HttpContext.Current.User.Identity.Name);
            Users staff = currentStaff.ReturnCurrentUser(currentIdStaff);
           
            Staff staff1 = context.Users.Find(1) as Staff;
            if(singletonInstance == null) {

                singletonInstance = new ClinicRegistryManager { ClinicRegistryManagerId = AccessDatabase(patient, staff1, context).ClinicRegistryManagerId };
            }

            return context.ClinicRegistryManagers.Find(singletonInstance.ClinicRegistryManagerId);
        }

        public static ClinicRegistryManager AccessDatabase(Patient patient, Users staff, HPCareDBContext context) {
            using (SqlConnection connection = new SqlConnection("Data Source= WANJIKU\\NEWSQLEXPRESS ; Initial Catalog =HPCareDBContext;Integrated Security=SSPI"))
            {
             
                SqlCommand command = new SqlCommand("insert into ClinicRegistryManagers (Clinic_patient_User_id, Staff_doctor_User_id) values ( " + patient.User_id + ", " + staff.User_id + "); select scope_identity();", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                int id = System.Convert.ToInt32(command.ExecuteScalar());

                return new ClinicRegistryManager { ClinicRegistryManagerId = id };
            }

        }
    }
}