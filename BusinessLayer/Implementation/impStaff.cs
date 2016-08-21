using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.EntityFramework;
using DataLayer.Entities.UserEntities;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer.Implementation {
    public class impStaff : IStaff {

        private HPCareDBContext db;

        public impStaff(HPCareDBContext db) {
            this.db = db;
        }

        public void saveStaffInformations(List<Staff> staffInformation) {
            Staff staff = db.Users.Find(1) as Staff; //current logged user

            foreach(Staff s in staffInformation) {
                staff.Address = s.Address;
                staff.Email = s.Email;
                //staff.gender = s.gender;
                //staff.MaritalStatus = s.MaritalStatus;
                staff.Name = s.Name;
                staff.Telephone = s.Telephone;

                if(s.gender != null) {
                    AccessDatabaseGender(s.gender.GenderId, staff.User_id);
                }

                if(s.MaritalStatus != null) {
                    AccessDatabaseStatus(s.MaritalStatus.MaritalStatusId, staff.User_id);
                }

            }

            db.SaveChanges();
        }

        public void AccessDatabaseGender(int gender, int idStaff) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                //using(SqlConnection connection = new SqlConnection("Data Source= MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=SSPI")) {
                SqlCommand command = new SqlCommand("update users set gender_GenderId = " + gender + " where user_id = " + idStaff + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void AccessDatabaseStatus(int status, int idStaff) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                //using(SqlConnection connection = new SqlConnection("Data Source= MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=SSPI")) {
                SqlCommand command = new SqlCommand("update users set MaritalStatus_MaritalStatusId = " + status + " where user_id = " + idStaff + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

    }

}
