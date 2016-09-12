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

namespace BusinessLayer.Implementation {
    public class ImpHome {

        /// <summary>
        /// Accesses the database.
        /// </summary>
        /// <param name="PatientToSearch">The patient to search.</param>
        /// <returns></returns>
        public PatientViewModel AccessDatabase(string PatientToSearch) {
            using (SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {

                SqlCommand command = new SqlCommand("select * from Users where user_identification = '" + PatientToSearch + "';", connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                int id = 0;
                while (dbDataReader.Read()) {
                    id = GetIntSafely(dbDataReader, 0);
                }
                dbDataReader.Close();
                return (id == 0 ? null : new impPatientViewModel().getPatientInformation(id));
            }
        }

        /// <summary>
        /// Get int safely in case the dbReader is null
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        private int GetIntSafely(DbDataReader reader, int colIndex) {
            return (reader.IsDBNull(colIndex) ? 0 : reader.GetInt32(colIndex));
        }

        private void insert() {
            HPCareDBContext context = new HPCareDBContext();
            context.MCDTs.Add(new KFT { });
            context.MCDTs.Add(new LFT { });
            context.MCDTs.Add(new WBCS { });
            context.MCDTs.Add(new RBCS { });
            context.MCDTs.Add(new RBCIndices { });
            context.MCDTs.Add(new PlateletsCount { });
            context.MCDTs.Add(new ViralLoad { });
            context.MCDTs.Add(new LymphocytesSubsets { });
            context.SaveChanges();

        }

    }

}

