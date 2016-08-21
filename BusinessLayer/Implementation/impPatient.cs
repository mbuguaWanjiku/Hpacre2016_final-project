using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.EntityFramework;

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
            }

            db.SaveChanges();
        }
    }
}
