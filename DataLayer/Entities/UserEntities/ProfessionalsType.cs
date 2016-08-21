using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    //public enum ProfessionalsType {

    //    Doctor,
    //    Nurse,
    //    LabTechnician, 
    //    Student, 
    //    Driver, 
    //    Other

    //}

    public class ProfessionalsType {

        [Key]
        public int ProfessionalId {
            get; set;
        }

        public string ProfessionalName {
            get; set;
        }

    }
}
