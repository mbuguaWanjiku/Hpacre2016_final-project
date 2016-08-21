using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.TreatmentEntities {
    public class Therapy {

        [Key]
        public int Therapy_id {
            get; set;
        }

        public string Therapy_designation {
            get; set;
        }

        public DateTime Therapy_start_hour {
            get; set;
        }

        public DateTime Therapy_end_hour {
            get; set;
        }
        /// <summary>
        /// nav prop
        /// </summary>
        public virtual  TherapyManager TherapyManager
        {
            get; set;
        }

    }
}
