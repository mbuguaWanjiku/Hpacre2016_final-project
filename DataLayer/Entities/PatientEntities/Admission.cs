using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.PatientEntities {
    public class Admission {

        [Key]
        public int Admission_id {
            get; set;
        }

        public DateTime Admission_date_in {
            get; set;
        }

        public DateTime Admission_date_out {
            get; set;
        }

        public string Admission_cause {
            get; set;
        }
       public Patient Admission_Patient_Id { get; set; }

    }
}
