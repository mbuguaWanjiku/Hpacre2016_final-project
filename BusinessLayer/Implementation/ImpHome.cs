using BusinessLayer.Implementation.ViewModels;
using DataLayer.Entities;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.MCDTEntities;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Implementation
{
    public class ImpHome
    {

        /// <summary>
        /// Accesses the database.
        /// </summary>
        /// <param name="PatientToSearch">The patient to search.</param>
        /// <returns>Patient view model</returns>
        public PatientViewModel AccessDatabase(string PatientToSearch)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;"))
            {

                SqlCommand command = new SqlCommand("select * from Users where user_identification = '" + PatientToSearch + "';", connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                int id = 0;
                while (dbDataReader.Read())
                {
                    id = GetIntSafely(dbDataReader, 0);
                }
                dbDataReader.Close();
                return (id == 0 ? null : new impPatientViewModel().getPatientInformation(id));
            }
        }

        /// <summary>
        /// Get int safely in case the dbReader is null
        /// </summary>
        /// <param name="reader">database reader</param>
        /// <param name="colIndex">reader column index</param>
        /// <returns></returns>
        private int GetIntSafely(DbDataReader reader, int colIndex)
        {
            return (reader.IsDBNull(colIndex) ? 0 : reader.GetInt32(colIndex));
        }
        public bool IsFirstVist(HPCareDBContext context)
        {

            Patient patient = context.Users.Find(HttpContext.Current.Session["patientId"]) as Patient;
            return patient.Address == null;
        }

        public List<UsersSearchVM> SearchUsers(HPCareDBContext context)
        {
            List<Users> users = context.Users.ToList();
            List<UsersSearchVM> usersVM = new List<UsersSearchVM>();
            UsersSearchVM vm = null;
            foreach (Users user in users)
            {
                vm = new UsersSearchVM
                {
                    Name = user.Name,
                    Address = user.Address,
                    Email = user.Email,
                    Type = setUserType(1)
                };
                usersVM.Add(vm);
            }

            return usersVM;
        }
        private string setUserType(int type)
        {
            return (type == 0 ? "admin" : type == 1 ? "clinic": type == 2 ?"labTec":type ==3?"nurse":"Patient");
        }
    }
}





