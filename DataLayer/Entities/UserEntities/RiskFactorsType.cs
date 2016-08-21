using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.UserEntities {
    public class RiskFactorsCategory {

        [Key]
        public int RiskFactorsCategoryId {
            get; set;
        }

        public string RiskFactorsName {
            get; set;
        }

    }
}
