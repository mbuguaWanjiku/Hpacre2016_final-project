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

namespace BusinessLayer.Implementation {
    public class impPatient : IPatient {

        private HPCareDBContext db;

        public impPatient(HPCareDBContext db) {
            this.db = db;
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
    }
}
