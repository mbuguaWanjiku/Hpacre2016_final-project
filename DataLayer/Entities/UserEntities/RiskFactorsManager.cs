using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    public class RiskFactorsManager {

        [Key]
        public int RiskFactorsManager_id {
            get; set;
        }

        public int RiskFactorsManagerRiskFactorId {
            get; set;
        }

        public virtual Patient RiskFactorsManager_PatientId {
            get; set;
        }

    }
}
