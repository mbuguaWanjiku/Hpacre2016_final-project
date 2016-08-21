using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.TreatmentEntities {
    public class DrugManager {

        [Key]
        public int MedicationManager_id {
            get; set;
        }

        /// <summary>
        /// Navigation prop
        /// </summary>
        public virtual ClinicRegistryManager Clinic_registry_manager {
            get; set;
        }
        /// <summary>
        /// Nav prop
        /// </summary>
        public List<DrugIssuance> Medications_Issuances {
            get; set;
        }



    }
}
