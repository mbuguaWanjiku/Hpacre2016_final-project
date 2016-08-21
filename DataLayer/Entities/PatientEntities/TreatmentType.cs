using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.PatientEntities {
    public class TreatmentType {

        public int id {
            get; set;
        }
        public string Description {
            get; set;
        }
        /// <summary>
        /// Navigation prop
        /// </summary>
        public virtual TreatmentCategory TreatmentCategory {
            get; set;
        }
    }
}


//Medication, 
//        BloodTransfusion, 
//        Physiotheraphy,
//        Surgery,
//        Dermatology