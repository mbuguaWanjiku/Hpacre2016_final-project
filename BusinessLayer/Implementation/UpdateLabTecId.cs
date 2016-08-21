using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation {
    public class UpdateLabTecId {

        public void AccessDatabase(int currentUser, int idManager) {
            //using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
            //using(SqlConnection connection = new SqlConnection("Data Source=MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=true")) {
            using (SqlConnection connection = new SqlConnection("Data Source= WANJIKU\\NEWSQLEXPRESS ; Initial Catalog =HPCareDBContext;Integrated Security=SSPI"))
            {
                SqlCommand command = new SqlCommand("update MCDTStaffManagers set Staff_User_id = " + currentUser + " where MCDTStaffManager_id = " + idManager + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}
