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
using BusinessLayer.Implementation.ViewModels;
using System.Data.Common;

namespace BusinessLayer.Implementation {
    public class impStaff : IStaff {

        private HPCareDBContext db;
        private CurrentUserId current;
        private List<StaffViewModel> staffList;

        public impStaff(HPCareDBContext db) {
            this.db = db;
            current = new CurrentUserId();
            staffList = new List<StaffViewModel>();
        }

        public void saveStaffInformations(List<Staff> staffInformation, int staffId) {
            Staff staff = db.Users.Find(staffId) as Staff;

            foreach (Staff s in staffInformation) {
                if (s.Address != null) {
                    staff.Address = s.Address;
                }
                if (s.Email != null) {
                    staff.Email = s.Email;
                }
                if (s.Name != null) {
                    staff.Name = s.Name;
                }
                if (s.Telephone != null) {
                    staff.Telephone = s.Telephone;
                }
                if (s.gender != null) {
                    AccessDatabaseGender(s.gender.GenderId, staff.User_id);
                }
                if (s.MaritalStatus != null) {
                    AccessDatabaseStatus(s.MaritalStatus.MaritalStatusId, staff.User_id);
                }

            }

            db.SaveChanges();
        }

        public void AccessDatabaseGender(int gender, int idStaff) {
            using (SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                //using(SqlConnection connection = new SqlConnection("Data Source= MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=SSPI")) {
                SqlCommand command = new SqlCommand("update users set gender_GenderId = " + gender + " where user_id = " + idStaff + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void AccessDatabaseStatus(int status, int idStaff) {
            using (SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                //using(SqlConnection connection = new SqlConnection("Data Source= MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=SSPI")) {
                SqlCommand command = new SqlCommand("update users set MaritalStatus_MaritalStatusId = " + status + " where user_id = " + idStaff + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public List<StaffViewModel> GetStaffInformations(int idStaff) {
            AccessDatabaseStaffInformation(idStaff);
            return staffList;
        }

        private void AccessDatabaseStaffInformation(int idStaff) {
            Staff s = db.Users.Find(idStaff) as Staff;

            using (SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                SqlCommand command = new SqlCommand("select address, email, genderName, maritalstatusname, name, telephone, user_identification, ProfessionalName" +
                " from users, genders, maritalstatus, professionalstypes, staff where gender_genderid = genderid and MaritalStatus_MaritalStatusId = MaritalStatusId " +
                " and staff.ProfessionalType_ProfessionalId = ProfessionalsTypes.ProfessionalId  and staff.User_id = users.User_id and users.user_id = " + idStaff + "; ", connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();

                DbDataReader dbDataReader = command.ExecuteReader();
                StaffViewModel viewModel;

                while (dbDataReader.Read()) {
                    viewModel = new StaffViewModel {
                        Address = GetStringSafely(dbDataReader, 0),
                        Email = GetStringSafely(dbDataReader, 1),
                        gender = GetStringSafely(dbDataReader, 2),
                        MaritalStatus = GetStringSafely(dbDataReader, 3),
                        Name = GetStringSafely(dbDataReader, 4),
                        Telephone = GetStringSafely(dbDataReader, 5),
                        User_identification = GetStringSafely(dbDataReader, 6),
                        ProfessionalType = GetStringSafely(dbDataReader, 7)
                    };
                    staffList.Add(viewModel);
                }
            }
        }

        private string GetStringSafely(DbDataReader reader, int colIndex) {
            return (reader.IsDBNull(colIndex) ? "-" : reader.GetString(colIndex));
        }
    }

}
