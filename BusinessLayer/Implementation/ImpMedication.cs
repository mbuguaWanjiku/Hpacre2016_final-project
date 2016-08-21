using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.TreatmentEntities;
using DataLayer.EntityFramework;
using System.Data.Entity;

namespace BusinessLayer.Implementation
{
    public class ImpMedication : IMedication
    {
        private HPCareDBContext db;
        public ImpMedication(HPCareDBContext db)
        {
            this.db = db;
        }
        public void savePrescribedMedication(List<DrugIssuance> prescibedMedication)
        {
            DrugIssuance drugIssuance;
            DrugManager drugManager =
                new DrugManager { Clinic_registry_manager = SingletonClinicRegistry.GetInstance(db) };
            foreach (DrugIssuance issuance in prescibedMedication)
            {
                drugIssuance = new DrugIssuance
                {
                    IssuedDrug = db.Drugs.Find(issuance.IssuedDrug.Drug_id),
                    Medication_administration = db.DrugAdministrations.Find(issuance.Medication_administration.Administration_Id),
                    Medication_dosage = db.DrugDosages.Find(issuance.Medication_dosage.Dosage_id),
                    Medication_frequency = db.DrugFrequencies.Find(issuance.Medication_frequency.Frequency_id),
                    Medication_end_date = issuance.Medication_end_date,
                    Medication_start_date = issuance.Medication_start_date,
                    Medication_manager = drugManager

                };
                db.DrugInssuances.Add(drugIssuance);
            }

            db.SaveChanges();
        }
    }
}




