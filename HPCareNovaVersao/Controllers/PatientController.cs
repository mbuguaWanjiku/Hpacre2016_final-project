using BusinessLayer.Implementation;
using DataLayer.Entities;
using DataLayer.Entities.UserEntities;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers {
    public class PatientController : Controller {

        HPCareDBContext db = new HPCareDBContext();
        private impPatient impPatient;

        public PatientController() {
            impPatient = new impPatient(db);
        }

        // ************** Get Patient Informations ***************** //

        public ActionResult ListPatientInformation() {
            return PartialView();
        }

        public JsonResult GetPatientAllergies() {
            Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
            var list = from a in db.AllergiesManagers
                       from allergy in db.Allergies
                       where a.AllergiesManager_PatientId.User_id == p.User_id &&
                       allergy.Allergy_id == a.AllergiesManager_AllergiesId
                       select new {
                           a.Allergy_start_date,
                           a.Allergy_end_date,
                           allergy.Allergy_Name
                       };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientRiskFactors() {
            Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
            var list = from r in db.RiskFactorsManagers
                       from risk in db.RiskFactors
                       where r.RiskFactorsManager_PatientId.User_id == p.User_id
                       select new {
                           risk.RiskFactorName
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientFamilyHistory() {
            Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
            var list = from f in db.FamilyHistoryManagers
                       from family in db.FamilyHistories
                       where f.FamilyHistoryManager_PatientId.User_id == p.User_id
                       && family.FamilyHistory_id == f.FamilyHistoryManagerFamilyHistoryId
                       select new {
                           family.FamilyHistoryName,
                           f.Carrier
                       };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPatientInformations() {
            Patient p = db.Users.Find(2) as Patient; //ir buscar ao session
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

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // ****************** "Criacao" do Patient ***************** //

        public ActionResult AddPatientInformation() {
            return PartialView();
        }

        public JsonResult GetAllergiesCategoryJson() {
            List<AllergyCategory> category = db.AllergyCategories.ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllergiesJson(int categoryId) {
            List<Allergies> allergies = db.Allergies.Where(a => a.AllergyCategory.AllergyCategoryId == categoryId).ToList();
            return Json(allergies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRiskFactorsCategoryJson() {
            List<RiskFactorsCategory> category = db.RiskFactorsCategories.ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRiskFactorsJson(int categoryId) {
            List<RiskFactors> riskFactors = db.RiskFactors.Where(r => r.RiskFactorCategory.RiskFactorsCategoryId == categoryId).ToList();
            return Json(riskFactors, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFamilyHistoryCategoryJson() {
            List<FamilyHistoryCategory> category = db.FamilyHistoryCategories.ToList();
            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFamilyHistoryJson(int categoryId) {
            List<FamilyHistory> familyHistory = db.FamilyHistories.Where(f => f.FamilyHistoryCategory.FamilyHistoryCategoryId == categoryId).ToList();
            return Json(familyHistory, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SaveAllergies(List<AllergiesManager> allergies) {
            impPatient.saveAllergies(allergies, null);
        }

        [HttpPost]
        public void SaveRiskFactors(List<RiskFactorsManager> riskFactors) {
            impPatient.saveRiskFactors(riskFactors, null);
        }

        [HttpPost]
        public void SaveFamilyHistory(List<FamilyHistoryManager> familyHistory) {
            impPatient.saveFamilyHistory(familyHistory, null);
        }

        public JsonResult GetPatientInformation() {
            List<object> patientInformations = new List<object>();
            Users patient = db.Users.Find(2); //ir buscar atraves do session
            patientInformations.Add(patient.Email);
            patientInformations.Add(patient.Telephone);
            patientInformations.Add(patient.Address);
            return Json(patientInformations, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SaveInformations(List<Patient> usersInformations) {
            impPatient.saveDataFromPatient(usersInformations);
        }

    }
}