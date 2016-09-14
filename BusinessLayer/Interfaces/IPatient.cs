using DataLayer.Entities;
using DataLayer.Entities.TreatmentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces {
    interface IPatient {

        void saveAllergies(List<AllergiesManager> allergiesList, AllergiesManager allergiesManager);

        void saveRiskFactors(List<RiskFactorsManager> risksList, RiskFactorsManager riskFactorsManager);

        void saveFamilyHistory(List<FamilyHistoryManager> historiesList, FamilyHistoryManager familyHistoryManager);

        void saveDataFromPatient(List<Patient> usersInformations);

        void updateAllergies(List<AllergiesManager> allergies);

    }
}
