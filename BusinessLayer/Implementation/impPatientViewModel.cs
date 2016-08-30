using BusinessLayer.Implementation.ViewModels;
using DataLayer.Entities;
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
    public class impPatientViewModel {
        List<string> riskNamesList;
        List<string> familyHistoryList;
        List<string> allergiesList;

        HPCareDBContext db = new HPCareDBContext();

        public impPatientViewModel() {
            riskNamesList = new List<string>();
            familyHistoryList = new List<string>();
            allergiesList = new List<string>();
        }

        private List<string> addRiskFactorList(int idPatient) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                SqlCommand command = new SqlCommand("select RiskFactors.RiskFactorName from RiskFactorsManagers, RiskFactors, users " +
                     " where RiskFactorsManagers.RiskFactorsManagerRiskFactorId = RiskFactors.RiskFActors_id and " +
                      " Users.User_id = RiskFactorsManagers.RiskFactorsManager_PatientId_User_id and users.user_id = " + idPatient + ";", connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();

                DbDataReader dbDataReader = command.ExecuteReader();
                while(dbDataReader.Read()) {
                    riskNamesList.Add(dbDataReader.GetString(0));
                }
            }
            return riskNamesList;
        }

        private List<string> addFamilyHistoryList(int idPatient) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                SqlCommand command = new SqlCommand(" select FamilyHistories.FamilyHistoryName from FamilyHistoryManagers, users, FamilyHistories where " +
                    " FamilyHistoryManagers.FamilyHistoryManagerFamilyHistoryId = FamilyHistories.FamilyHistory_id and " +
                    " FamilyHistoryManagers.FamilyHistoryManager_PatientId_User_id = Users.User_id and Users.User_id = " + idPatient + ";", connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();

                DbDataReader dbDataReader = command.ExecuteReader();
                while(dbDataReader.Read()) {
                    familyHistoryList.Add(dbDataReader.GetString(0));
                }
            }
            return familyHistoryList;
        }

        private List<string> addAllergiesList(int idPatient) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                SqlCommand command = new SqlCommand("select Allergies.Allergy_Name from allergies, users, AllergiesManagers where " +
                    " AllergiesManagers.AllergiesManager_AllergiesId = Allergies.Allergy_id and " +
                    " AllergiesManagers.AllergiesManager_PatientId_User_id = users.user_id and users.user_id = " + idPatient + ";", connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();


                DbDataReader dbDataReader = command.ExecuteReader();
                while(dbDataReader.Read()) {
                    allergiesList.Add(dbDataReader.GetString(0));
                }
            }
            return allergiesList;
        }

        public PatientViewModel getPatientInformation(int idPatient) {
            Patient p = db.Users.Find(idPatient) as Patient;
            PatientViewModel viewModel = new PatientViewModel {
                Address = p.Address,
                AllergiesManager = addAllergiesList(idPatient),
                AspUserId = p.AspUserId,
                Email = p.Email,
                FamilyHistoryManager = addFamilyHistoryList(idPatient),
                gender = p.gender,
                MaritalStatus = p.MaritalStatus,
                Name = p.Name,
                Password = p.Password,
                Patient_Age_Group = p.Patient_Age_Group,
                Patient_next_of_kin = p.Patient_next_of_kin,
                RiskFactorManager = addRiskFactorList(idPatient),
                Telephone = p.Telephone,
                UserType = p.UserType,
                User_id = p.User_id,
                User_identification = p.User_identification
            };

            return viewModel;
        }
    }
}
