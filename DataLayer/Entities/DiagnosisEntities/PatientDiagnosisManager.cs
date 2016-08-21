using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.DiagnosisEntities {
    /// <summary>
    /// unused
    /// </summary>
    public class PatientDiagnosisManager {

        [Key]
        public int PatientDiagnosisManager_id {
            get; set;
        }

        /// <summary>
        /// Navigation prop
        /// </summary>
        public virtual Patient Patient_diagnosis {
            get; set;
        }
    }
}
