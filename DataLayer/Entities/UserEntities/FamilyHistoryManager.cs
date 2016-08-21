using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    public class FamilyHistoryManager {

        [Key]
        public int FamilyHistoryManager_id {
            get; set;
        }

        public int FamilyHistoryManagerFamilyHistoryId {
            get; set;
        }

        public string Carrier {
            get; set;
        }

        public virtual Patient FamilyHistoryManager_PatientId {
            get; set;
        }

    }
}
