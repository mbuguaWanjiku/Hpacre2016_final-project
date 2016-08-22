using DataLayer.Entities;
using DataLayer.Entities.TreatmentEntities;
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

namespace BusinessLayer.Implementation {
    public class ImpMedicationHistory {
        private HPCareDBContext db;
        private Patient patient;
        public ImpMedicationHistory() {
            db = new HPCareDBContext();
            patient = db.Users.Find(HttpContext.Current.Session["patientId"]) as Patient;
        }
        /// <summary>
        /// Getting all patinets clinical registries
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        private List<ClinicRegistryManager> GetPatientClinicalRegisties() {
            List<ClinicRegistryManager> clinicalRegistries =
                db.ClinicRegistryManagers.Where(x => x.Clinic_patient.User_id == patient.User_id).ToList();
            return clinicalRegistries;
        }

        /// <summary>
        /// Get all drug managers associated to the patinet registry
        /// </summary>
        /// <param name="drugIssuenceId"></param>
        /// <returns></returns>
        private List<DrugManager> GetDrugManagers(int registry) {
            return db.DrugManagers.Where(x => x.Clinic_registry_manager.ClinicRegistryManagerId == registry).ToList();
        }

        private List<DrugIssuance> GetListIssuances(DrugManager manager) {
            return (db.DrugInssuances.Where(x => x.Medication_manager.MedicationManager_id == manager.MedicationManager_id)).ToList();
        }

        public List<MedicationHistoryVm> GetPatientMedicationHistory() {
            List<MedicationHistoryVm> medicationHistoryList = new List<MedicationHistoryVm>();
            MedicationHistoryVm medHistory;
            List<DrugIssuance> drugIssuancesIDs = new List<DrugIssuance>();

            foreach(ClinicRegistryManager registry in GetPatientClinicalRegisties()) {
                foreach(DrugManager manager in GetDrugManagers(registry.ClinicRegistryManagerId)) {
                    foreach(DrugIssuance issuance in GetListIssuances(manager)) {
                        medHistory = new MedicationHistoryVm();

                        GetMedicationHistoryObject(issuance.DrugIssuance_id, medHistory);
                        medicationHistoryList.Add(medHistory);
                    }

                }

            }
            return medicationHistoryList;
        }

        private MedicationHistoryVm GetMedicationHistoryObject(int drugIssuance, MedicationHistoryVm medicationHistory) {

            StringBuilder stringJson = new StringBuilder();
            //using (SqlConnection dbConnection = new SqlConnection("Data Source= WANJIKU\\NEWSQLEXPRESS; Initial Catalog =HPCareDBContext; Integrated Security=SSPI"))
            using(SqlConnection dbConnection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {

                DbCommand dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                string query = " SELECT DrugCategories.description, Drugs.Drug_name, DrugIssuances.Medication_end_date,DrugIssuances.Medication_start_date, DrugIssuances.DrugIssuance_id FROM  DrugIssuances ,Drugs,DrugCategories where DrugIssuances.IssuedDrug_Drug_id = Drug_id and Drugs.Category_category_id = DrugCategories.category_id and DrugIssuance_id =" + drugIssuance;
                dbCommand.CommandText = query;
                dbConnection.Open();
                DbDataReader dbDataReader = dbCommand.ExecuteReader();
                while(dbDataReader.Read()) {
                    if(stringJson.Length != 0) {
                        stringJson.Append(",");
                    }
                    medicationHistory.Drugcategory = dbDataReader.GetString(0);
                    medicationHistory.DrugName = dbDataReader.GetString(1);
                    medicationHistory.EndDate = dbDataReader.GetDateTime(2);
                    medicationHistory.StartDate = dbDataReader.GetDateTime(3);
                    medicationHistory.Issance_ID = drugIssuance;
                }
                dbDataReader.Close();

            }
            return medicationHistory;
        }

    }
}
