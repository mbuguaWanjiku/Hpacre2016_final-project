using DataLayer.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    public class FamilyHistory {

        [Key]
        public int FamilyHistory_id {
            get; set;
        }

        public FamilyHistoryCategory FamilyHistoryCategory {
            get; set;
        }

        public string FamilyHistoryName {
            get; set;
        }

        ///// <summary>
        ///// navivation prop
        ///// </summary>
        //public virtual FamilyHistoryManager FamilyHistoryManager {
        //    get; set;
        //}
    }
}
