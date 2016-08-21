using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.DiagnosisEntities {
    public class Diagnosis {

        [Key]
        public int Diagnosis_id {
            get; set;
        }

        public Disease Diagnosis_disease {
            get; set;
        }

        public CIDCode Diagnosis_CID_code {
            get; set;
        }
        /// <summary>
        /// navigation prop
        /// </summary>
        public virtual ClinicRegistryManager ClinicRegistry_Manager {
            get; set;
        }
    }
}
