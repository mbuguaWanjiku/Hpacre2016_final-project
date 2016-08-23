using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.EntityFramework;
using System.Data.SqlClient;
using System.Data;
using BusinessLayer.Implementation.ViewModels;

namespace BusinessLayer.Implementation {
    public class impPatient : IPatient {

        private HPCareDBContext db;
        private List<AllergiesViewModel> allergyList;
        private List<RiskFactorsViewModel> riskList;
        private List<FamilyHistoryViewModel> historyList;
        private List<PatientInformationViewModel> patientInformationList;


        public impPatient(HPCareDBContext db) {
            this.db = db;
            allergyList = new List<AllergiesViewModel>();
            riskList = new List<RiskFactorsViewModel>();
            historyList = new List<FamilyHistoryViewModel>();
            patientInformationList = new List<PatientInformationViewModel>();
        }

        public void saveFamilyHistory(List<FamilyHistoryManager> historiesList, FamilyHistoryManager familyHistoryManager) {

            //Patient patient = db.Users.OfType<Patient>().Where(p => p.User_identification == "").First();//ir buscar atraves do session
            Patient patient = db.Users.Find(2) as Patient;

            foreach(FamilyHistoryManager history in historiesList) {

                familyHistoryManager = new FamilyHistoryManager {
                    Carrier = history.Carrier,
                    FamilyHistoryManagerFamilyHistoryId = history.FamilyHistoryManagerFamilyHistoryId,
                    FamilyHistoryManager_PatientId = patient
                };

                db.FamilyHistoryManagers.Add(familyHistoryManager);
            }

            db.SaveChanges();
        }

        public void saveAllergies(List<AllergiesManager> allergiesList, AllergiesManager allergiesManager) {
            Patient patient = db.Users.Find(2) as Patient; //ir buscar ao session

            foreach(AllergiesManager allergy in allergiesList) {

                allergiesManager = new AllergiesManager {
                    AllergiesManager_AllergiesId = allergy.AllergiesManager_AllergiesId,
                    AllergiesManager_PatientId = patient
                };

                db.AllergiesManagers.Add(allergiesManager);
            }

            db.SaveChanges();
        }

        public void saveRiskFactors(List<RiskFactorsManager> risksList, RiskFactorsManager riskFactorsManager) {
            Patient patient = db.Users.Find(2) as Patient; //ir buscar atraves do session

            foreach(RiskFactorsManager risk in risksList) {

                riskFactorsManager = new RiskFactorsManager {
                    RiskFactorsManagerRiskFactorId = risk.RiskFactorsManagerRiskFactorId,
                    RiskFactorsManager_PatientId = patient
                };

                db.RiskFactorsManagers.Add(riskFactorsManager);
            }

            db.SaveChanges();
        }

        public void saveDataFromPatient(List<Patient> usersInformations) {
            Patient patient = db.Users.Find(2) as Patient; //session

            foreach(Patient p in usersInformations) {
                patient.Email = p.Email;
                patient.Address = p.Address;
                patient.Telephone = p.Telephone;
                patient.Name = p.Name;

                if(p.gender != null) {
                    AccessDatabaseGender(p.gender.GenderId, patient.User_id);
                }

                if(p.MaritalStatus != null) {
                    AccessDatabaseStatus(p.MaritalStatus.MaritalStatusId, patient.User_id);
                }
            }

            db.SaveChanges();
        }

        public void AccessDatabaseGender(int gender, int idPatient) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                //using(SqlConnection connection = new SqlConnection("Data Source= MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=SSPI")) {
                SqlCommand command = new SqlCommand("update users set gender_GenderId = " + gender + " where user_id = " + idPatient + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public void AccessDatabaseStatus(int status, int idPatient) {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                //using(SqlConnection connection = new SqlConnection("Data Source= MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=SSPI")) {
                SqlCommand command = new SqlCommand("update users set MaritalStatus_MaritalStatusId = " + status + " where user_id = " + idPatient + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }

        }

        public List<AllergiesViewModel> GetPatientAllergies(int idPatient) {
            AccessGetPatientAllergies(idPatient);
            return allergyList;
        }

        private void AccessGetPatientAllergies(int patientId) {
            //Patient p = db.Users.Find(patientId) as Patient; //ir buscar ao session
            Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
            AllergiesViewModel viewModel;

            var list = from a in db.AllergiesManagers
                       from allergy in db.Allergies
                       where a.AllergiesManager_PatientId.User_id == p.User_id &&
                       allergy.Allergy_id == a.AllergiesManager_AllergiesId
                       select new {
                           a.Allergy_start_date,
                           a.Allergy_end_date,
                           allergy.Allergy_Name
                       };

            foreach(var item in list) {
                viewModel = new AllergiesViewModel {
                    Allergy_end_date = item.Allergy_end_date,
                    Allergy_start_date = item.Allergy_start_date,
                    Allergy_Name = item.Allergy_Name
                };
                allergyList.Add(viewModel);
            }

        }

        public List<RiskFactorsViewModel> GetPatientRiskFactors(int idPatient) {
            AccessGetPatientRiskFactors(idPatient);
            return riskList;
        }

        private void AccessGetPatientRiskFactors(int idPatient) {
            //Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
            Patient p = db.Users.Find(idPatient) as Patient; //ir buscar ao session
            RiskFactorsViewModel viewModel;

            var list = from r in db.RiskFactorsManagers
                       from risk in db.RiskFactors
                       where r.RiskFactorsManager_PatientId.User_id == p.User_id
                       select new {
                           risk.RiskFactorName
                       };

            foreach(var item in list) {
                viewModel = new RiskFactorsViewModel {
                    RiskFactorName = item.RiskFactorName
                };

                riskList.Add(viewModel);
            }
        }

        public List<FamilyHistoryViewModel> GetPatientFamilyHistory(int idPatient) {
            AccessGetPatientFamilyHistory(idPatient);
            return historyList;
        }


        private void AccessGetPatientFamilyHistory(int patientId) {
            Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
            //Patient p = db.Users.Find(patientId) as Patient; //ir buscar ao session
            FamilyHistoryViewModel viewModel;

            var list = from f in db.FamilyHistoryManagers
                       from family in db.FamilyHistories
                       where f.FamilyHistoryManager_PatientId.User_id == p.User_id
                       && family.FamilyHistory_id == f.FamilyHistoryManagerFamilyHistoryId
                       select new {
                           family.FamilyHistoryName,
                           f.Carrier
                       };

            foreach(var item in list) {
                viewModel = new FamilyHistoryViewModel {
                    Carrier = item.Carrier,
                    FamilyHistoryName = item.FamilyHistoryName
                };

                historyList.Add(viewModel);
            }

        }

        public List<PatientInformationViewModel> GetPatientInformation(int idPatient) {
            AccessGetPatientInformations(idPatient);
            return patientInformationList;
        }

        private void AccessGetPatientInformations(int idPatient) {
            Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
            //Patient p = db.Users.Find(idPatient) as Patient; //ir buscar ao session
            PatientInformationViewModel viewModel;

            var list = from u in db.Users
                       where u.User_id == p.User_id
                       select new {
                           u.Address,
                           u.Email,
                           u.gender,
                           u.MaritalStatus,
                           u.Name,
                           u.Telephone,
                           u.User_identification
                       };

            foreach(var item in list) {
                viewModel = new PatientInformationViewModel {
                    Address = item.Address,
                    Email = item.Email,
                    gender = item.gender.GenderName,
                    MaritalStatus = item.MaritalStatus.MaritalStatusName,
                    Name = item.Name,
                    Telephone = item.Telephone,
                    User_identification = item.User_identification
                };
                patientInformationList.Add(viewModel);
            }

        }
    }
}
