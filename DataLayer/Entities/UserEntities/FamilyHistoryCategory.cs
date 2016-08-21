using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.UserEntities {
    public class FamilyHistoryCategory {

        [Key]
        public int FamilyHistoryCategoryId {
            get; set;
        }

        public string FamilyHistoryCategoryName {
            get; set;
        }

    }
}
