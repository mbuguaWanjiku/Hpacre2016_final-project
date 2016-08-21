using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    public class AllergiesManager {

        [Key]
        public int AllergiesManager_id {
            get; set;
        }

        public Nullable<DateTime> Allergy_start_date {
            get; set;
        }

        public Nullable<DateTime> Allergy_end_date {
            get; set;
        }

        public int AllergiesManager_AllergiesId {
            get; set;
        }

        public virtual Patient AllergiesManager_PatientId {
            get; set;
        }
    }
}
