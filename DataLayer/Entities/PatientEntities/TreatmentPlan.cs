using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.PatientEntities {
    public class TreatmentPlan {

        [Key]
        public int Treatment_id {
            get; set;
        }

        public virtual List<Intervention> TreatmentInterventions {
            get; set;
        }

        public Patient Patient_TreatmentPlan {
            get; set;
        }
    }
}
