using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation {

    public class CurrentUserId {

        /// <summary>
        /// Accesses the database. Returns the id of the current logged user. Returns 0 if there is no user.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <returns>User id</returns>
        public int AccessDatabase(string currentUser) {
            int id = 0;
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {

                SqlCommand command = new SqlCommand("select user_id from aspnetusers, users where AspNetUsersId = AspUserId and UserName = '" + currentUser + "';", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                while(dbDataReader.Read()) {
                    id = dbDataReader.GetInt32(0);
                }
                dbDataReader.Close();
                return id;
            }

        }

        /// <summary>
        /// Returns the current user.
        /// </summary>
        /// <param name="idCurrentUser">The identifier current user.</param>
        /// <returns></returns>
        public Users ReturnCurrentUser(int idCurrentUser) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                SqlCommand command = new SqlCommand("select * from Users where user_id = '" + idCurrentUser + "';", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                Users patient = new Patient();
                while(dbDataReader.Read()) {
                    patient.User_id = dbDataReader.GetInt32(0);
                }
                dbDataReader.Close();
                return patient;
            }
        }

    }
}
