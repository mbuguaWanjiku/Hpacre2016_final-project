using BusinessLayer.Interfaces;
using DataLayer.Entities.DiagnosisEntities;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Entities.Visitas;
using System.Data.Entity.Infrastructure;
using BusinessLayer.Implementation;
using System.Web;

namespace BusinessLayer.Implementation
{/// <summary>
/// This class implements patient IDiagnosis interface
/// the constructor receives context as a parameter
/// </summary>
    public class impDiagnosis : IDiagnosis
    {

       private HPCareDBContext db;

        public impDiagnosis(HPCareDBContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// Deactivate patient's disease/diagnosis by adding the end date hence it pertains 
        /// to the histrory for future reference
        /// </summary>
        /// <param name="diseaseId">The disease id associated to the diagnosis</param>
        /// <returns>success/insuccess message</returns>
        public string DeactivateDisease(int diseaseId)
        {
            if (diseaseId > 0)
            {

                Disease diseaseUpdated = db.Diseases.Find(diseaseId);
                diseaseUpdated.Disease_is_active = false;
                diseaseUpdated.Disease_end_date = DateTime.Now;
                db.Entry(diseaseUpdated).State = EntityState.Modified;
                db.SaveChanges();

                return "Disease Deactivated";

            }
            else
            {
                return "Invalid data";
            }
        }

        /// <summary>
        /// Saves the prescribed diagnosis,uses auxilliary function saveDiagnosisAUX 
        /// 
        /// </summary>
        /// <param name="classifications">Is list if CID codes/code  objects </param>
        public void SaveDiagnosis(List<CID_DiseaseCode> classifications)
        {
            foreach (CID_DiseaseCode diseaseCODE in classifications)
            {
                saveDiagnosisAUX(diseaseCODE);
            }
        }
        /// <summary>
        /// is an auxilliary function and receives a single ICD object as a param
        /// aaociated the code to the disease object and consequently
        /// to the clincRegistry instance 
        /// </summary>
        /// <param name="disCode">ICD code object</param>
        private void saveDiagnosisAUX(CID_DiseaseCode disCode)
        {        
            CIDCode diseaseCode = db.CIDCodes.Where(x => x.CID_DiseaseCode.DiseaseCode == disCode.DiseaseCode &&
            x.CID_DiseaseCode.CIDCategory.CID_CategorID == disCode.CIDCategory.CID_CategorID).FirstOrDefault();
            Disease disease = new Disease { Disease_start_date = DateTime.Now, Disease_is_active = true };
            ClinicRegistryManager registry = SingletonClinicRegistry.GetInstance(db);
            try
            {
                Diagnosis diagnosis = new Diagnosis { Diagnosis_CID_code = diseaseCode, Diagnosis_disease = disease, ClinicRegistry_Manager = registry };
                db.Diagnoses.Add(diagnosis);
                db.SaveChanges();
                //db.Entry(diagnosis).State = EntityState.Detached;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

    }
}