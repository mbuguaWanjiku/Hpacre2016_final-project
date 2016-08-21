using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.TreatmentEntities
{
    public class DrugIssuance
    {
        [Key]
        public int DrugIssuance_id { get; set; }
        public virtual Drug IssuedDrug { get; set; }

        public Nullable<DateTime> Medication_start_date
        {
            get; set;
        }

        public Nullable<DateTime> Medication_end_date
        {
            get; set;
        }

        public virtual Dosage Medication_dosage
        {
            get; set;
        }
        public virtual DrugFrequency Medication_frequency
        {
            get; set;
        }
        public virtual DrugAdministration Medication_administration
        {
            get; set;
        }
        /// <summary>
        /// One patient can have various prescriptions on a single visit
        /// </summary>
        public virtual DrugManager Medication_manager
        {
            get; set;
        }
    }
}
