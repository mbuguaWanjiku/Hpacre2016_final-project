using BusinessLayer.Implementation.ViewModels;
using DataLayer.Entities;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.Visitas;
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

namespace BusinessLayer.Implementation {/// <summary>
/// This class have a single public fuction which retrieves regular exams history
/// </summary>
    public class ImpRegularExamsHistory {
        private HPCareDBContext db;
        private Patient patient;
        private string discriminator;
        private List<RegularExamsVM> listRegularExam;
        public ImpRegularExamsHistory(HPCareDBContext db) {
            this.db = db;
            patient = db.Users.Find(HttpContext.Current.Session["patientId"]) as Patient;
            listRegularExam = new List<RegularExamsVM>();
        }
        /// <summary>
        /// This function returns a historic data list of specified lab exam 
        /// </summary>
        /// <param name="discriminator">The name or identifier of the exam type</param>
        /// <returns>Historic data associated to the patient</returns>
        public List<RegularExamsVM> GetRegularExamsHistory(string discriminator) {
            setRegularLabsList(discriminator);
            return listRegularExam;
        }
        /// <summary>
        /// retrieves the patient's registries
        /// </summary>
        /// <returns>patient associated registries</returns>
        private List<ClinicRegistryManager> GetPatientClinicalRegisties() {
            List<ClinicRegistryManager> clinicalRegistries =
                db.ClinicRegistryManagers.Where(x => x.Clinic_patient.User_id == patient.User_id).ToList();
            return clinicalRegistries;
        }
        private void setRegularLabsList(string discriminator) {
            foreach (ClinicRegistryManager registry in GetPatientClinicalRegisties()) {
                SetRegularLabsListAUX(discriminator, registry.ClinicRegistryManagerId);
            }

        }
        /// <summary>
        /// creates the labexams viewmodel
        /// </summary>
        /// <param name="discriminator">lab exam identifier</param>
        /// <param name="clinicalReg">Registry id</param>
        private void SetRegularLabsListAUX(string discriminator, int clinicalReg) {

            StringBuilder stringJson = new StringBuilder();
            using (SqlConnection dbConnection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;"))

                // using (SqlConnection dbConnection = new SqlConnection("Data Source= WANJIKU\\NEWSQLEXPRESS; Initial Catalog =HPCareDBContext; Integrated Security=SSPI"))
                {
                DbCommand dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                string query = " SELECT  MCDTs.MCDT_ID, MCDTs.MCDT_date, MCDTs.LabExam_data_in, MCDTs.LabExam_date_out," +
                                 "MCDTs.MCDT_units_Id, MCDTStaffManagers.Staff_User_id,Discriminator FROM ClinicRegistryManagers INNER JOIN " +
                                 "MCDTManagers ON ClinicRegistryManagers.ClinicRegistryManagerId = MCDTManagers.clinicRegistryManager_ClinicRegistryManagerId " +
                                  "INNER JOIN MCDTStaffManagers ON MCDTManagers.MCDTStaffManager_MCDTStaffManager_id = MCDTStaffManagers.MCDTStaffManager_id INNER JOIN " +
                                 " MCDTs ON MCDTStaffManagers.mcdt_MCDT_ID = MCDTs.MCDT_ID" +
                                 " and Discriminator = '" + discriminator + "' AND clinicRegistryManager_ClinicRegistryManagerId = " + clinicalReg +
                                  "AND LabExam_data_in != '' AND  LabExam_date_out != ''";
                dbCommand.CommandText = query;
                dbConnection.Open();
                DbDataReader dbDataReader = dbCommand.ExecuteReader();
                RegularExamsVM viewModel;
                while (dbDataReader.Read()) {
                    viewModel = new RegularExamsVM();
                    viewModel.Mcdt_id = dbDataReader.GetInt32(0);
                    viewModel.MCDT_date = dbDataReader.GetDateTime(1);
                    viewModel.LabExam_data_in = GetDateSafely(dbDataReader, 2);
                    viewModel.LabExam_data_out = GetDateSafely(dbDataReader, 3);
                    viewModel.MCDT_units_Id = GetMcdtUnits(GetIntSafely(dbDataReader, 4), viewModel.Mcdt_id);
                    viewModel.Staff_User_id = GetStaffName(GetIntSafely(dbDataReader, 5));
                    viewModel.Discriminator = dbDataReader.GetString(6);
                    listRegularExam.Add(viewModel);
                }

            }

        }

        /// <summary>
        /// handles error incase the data reader is null 
        /// </summary>
        /// <param name="reader">database reader</param>
        /// <param name="colIndex">column index</param>
        /// <returns>date time</returns>
        private DateTime GetDateSafely(DbDataReader reader, int colIndex) {
            return (reader.IsDBNull(colIndex) ? new DateTime(1920, 10, 10) : reader.GetDateTime(colIndex));
        }
        /// <summary>
        /// handles error incase the data reader is null 
        /// </summary>
        /// <param name="reader">database reader</param>
        /// <param name="colIndex">column index</param>
        /// <returns>integer</returns>
        private int GetIntSafely(DbDataReader reader, int colIndex) {
            return (reader.IsDBNull(colIndex) ? 0 : reader.GetInt32(colIndex));
        }
        /// <summary>
        /// handles error incase the data reader is null 
        /// </summary>
        /// <param name="reader">database reader</param>
        /// <param name="colIndex">column index</param>
        /// <returns>string</returns>
        private string GetStaffName(int id) {
            return(id==0 ? "unset":
                  db.Users.Where(x => x.User_id == id).FirstOrDefault().Name);
        }
        private string GetMcdtUnits(int unitId,int mcdtId)
        {
            MCDT mcdt = db.MCDTs.Find(mcdtId);
            db.Entry(mcdt).Reference(x => x.MCDT_units).Load();
            string units = mcdt.MCDT_units.Description;
            return units;
        }
    }
}