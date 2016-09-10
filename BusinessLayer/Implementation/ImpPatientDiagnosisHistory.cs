using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.Entities;
using DataLayer.Entities.DiagnosisEntities;
using DataLayer.EntityFramework;
using DataLayer.Entities.Visitas;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System;

namespace BusinessLayer.Implementation {
    public class ImpPatientDiagnosisHistory {
        private HPCareDBContext db;
        private bool state;
        public ImpPatientDiagnosisHistory(HPCareDBContext db ,bool state)
        {
            this.db = db;
            this.state = state;
        }
        /// <summary>
        /// This function return the diagnoisis history of the "current patient"
        /// </summary>
        /// <param name="patient">
        /// patient is the patient being attended,the param retrives associated clinical registry
        /// </param>
        /// <returns>
        /// Rtuens a list of the past diseases
        /// </returns>

        public List<PatientDiseaseHistoryVM> GetDiagnosisHistory(Patient patient) {
            //List<PatientDiseaseHistoryaAUX> patientHistory = new List<PatientDiseaseHistoryaAUX>();
            PatientDiseaseHistoryVM diseaseHistory = null;
            List<PatientDiseaseHistoryVM> listaBuilder = new List<PatientDiseaseHistoryVM>();

            foreach(int diagnosisID in GetPatientDiagnoses(patient)) {
                diseaseHistory = new PatientDiseaseHistoryVM();
                PatientDiseaseHistoryVM diagnosisHistory = GetDiagnosisHistoryObject(diagnosisID, diseaseHistory);
                if (diseaseHistory.Disease_id != 0)
                {
                    listaBuilder.Add(diseaseHistory);
                }
            }
            return listaBuilder;
        }

        public List<int> GetPatientDiagnoses(Patient patient) {
            List<Diagnosis> diagnosisRegistry = new List<Diagnosis>();
            List<int> diagnosisIDs = new List<int>();

            foreach(ClinicRegistryManager registry in GetPatientClinicalRegisties(patient)) {
                foreach(Diagnosis id in GetClinicalRegistryDiagnoses(registry.ClinicRegistryManagerId)) {

                    //if(isInactive(id.Diagnosis_id)) {
                        diagnosisIDs.Add(id.Diagnosis_id);
                    //}

                }

            }
            return diagnosisIDs;
        }

        /// <summary>
        /// filtering inacive diseases
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //private bool isInactive(int id) {
        //    int count = db.Diagnoses.Where(x => x.Diagnosis_disease.Disease_is_active == true && x.Diagnosis_id == id).Count();
        //    return (count < 1);
        //}

        /// <summary>
        /// This functions returns a list of diagnosis associated with the 
        /// </summary>
        /// <param name="clinicalRegistryID"></param>
        /// <returns>
        /// returns a list of diagnosis associated with the clinical registry
        /// </returns>
        public List<Diagnosis> GetClinicalRegistryDiagnoses(int clinicalRegistryID) {
            return db.Diagnoses.Where(x => x.ClinicRegistry_Manager.ClinicRegistryManagerId == clinicalRegistryID).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>
        /// Returns a list of 
        /// </returns>
        public List<ClinicRegistryManager> GetPatientClinicalRegisties(Patient patient) {
            List<ClinicRegistryManager> clinicalRegistries =
                db.ClinicRegistryManagers.Where(x => x.Clinic_patient.User_id == patient.User_id).ToList();
            return clinicalRegistries;
        }

        private PatientDiseaseHistoryVM GetDiagnosisHistoryObject(int diagnosisID, PatientDiseaseHistoryVM patientDiagnosis) {

            StringBuilder stringJson = new StringBuilder();
            using(SqlConnection dbConnection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;"))

                //using (SqlConnection dbConnection = new SqlConnection("Data Source= WANJIKU\\NEWSQLEXPRESS; Initial Catalog =HPCareDBContext; Integrated Security=SSPI"))
                {
                DbCommand dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                string query = " SELECT CID_Category.Description, CID_DiseaseCode.DiseaseCode, CIDCodes.Version, Diseases.Disease_start_date, Diseases.Disease_end_date, Diagnosis.ClinicRegistry_Manager_ClinicRegistryManagerId, Disease_id FROM CID_Category INNER JOIN  CID_DiseaseCode ON CID_Category.CID_CategorID = CID_DiseaseCode.CIDCategory_CID_CategorID INNER JOIN CIDCodes ON CID_DiseaseCode.DiseaseCID_ID = CIDCodes.CID_DiseaseCode_DiseaseCID_ID INNER JOIN Diagnosis ON CIDCodes.CIDCOD_id = Diagnosis.Diagnosis_CID_code_CIDCOD_id INNER JOIN Diseases ON Diagnosis.Diagnosis_disease_Disease_id = Diseases.Disease_id  AND Disease_is_active = '"+state+"' AND Diagnosis.Diagnosis_id = " + diagnosisID;
                dbCommand.CommandText = query;
                dbConnection.Open();
                DbDataReader dbDataReader = dbCommand.ExecuteReader();
                while(dbDataReader.Read()) {
                    if(stringJson.Length != 0) {
                        stringJson.Append(",");
                    }

                    patientDiagnosis.DiseaseCIDCategory = dbDataReader.GetString(0);
                    patientDiagnosis.DiseaseCIDCode = dbDataReader.GetString(1);
                    patientDiagnosis.Version = dbDataReader.GetString(2);
                    patientDiagnosis.StartDate = dbDataReader.GetDateTime(3);
                    patientDiagnosis.EndDate = GetDateSafely(dbDataReader, 4);
                    patientDiagnosis.PhysicianName = setPhysicianName(dbDataReader.GetInt32(5));
                    patientDiagnosis.Disease_id = dbDataReader.GetInt32(6);
                }
                dbDataReader.Close();

            }
            return patientDiagnosis;
        }

        private string setPhysicianName(int id)
        { ClinicRegistryManager registry = db.ClinicRegistryManagers.Where(x => x.ClinicRegistryManagerId == id).FirstOrDefault();
            db.Entry(registry).Reference(x => x.Staff_doctor).Load();
           return registry.Staff_doctor.Name;
        }
        private DateTime GetDateSafely(DbDataReader reader, int colIndex)
        {
            return (reader.IsDBNull(colIndex) ? new DateTime(1970,01,01) : reader.GetDateTime(colIndex));
        }

    }
}
