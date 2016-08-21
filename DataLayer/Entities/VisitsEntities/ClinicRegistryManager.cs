using DataLayer.Entities.DiagnosisEntities;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.PatientEntities;
using DataLayer.Entities.TreatmentEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Visitas {
    public class ClinicRegistryManager {

        [Key]
        public int ClinicRegistryManagerId {
            get; set;
        }

        /// <summary>
        /// Navigation prop
        /// </summary>
        public Patient Clinic_patient {
            get; set;
        }
        /// <summary>
        /// doente pode ter mais de um doenca
        /// </summary>

        public virtual List<MCDTManager> MCDT_manager {
            get; set;
        }

        /// <summary>
        /// doente pode ter varios diagnosticos
        /// </summary>

        public virtual List<Diagnosis> diagnosis {
            get; set;
        }

        /// <summary>
        /// O doente pode ter vários medicamentos 
        /// </summary>

        public virtual List<DrugManager> Medication_manager {
            get; set;
        }

        public virtual List<TherapyManager> therapy {
            get; set;
        }

        public virtual Staff Staff_doctor {
            get; set;
        }



    }
}
