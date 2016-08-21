using DataLayer.Entities.DiagnosisEntities;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.PatientEntities;
using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    public class Patient : Users {

        public AgeGroup Patient_Age_Group {
            get; set;
        }

        public virtual List<RiskFactorsManager> RiskFactorManager {
            get; set;
        }

        public virtual List<AllergiesManager> AllergiesManager {
            get; set;
        }

        public virtual List<FamilyHistoryManager> FamilyHistoryManager {
            get; set;
        }
 
        public NextOfKin Patient_next_of_kin {
            get; set;
        }

    }
}
