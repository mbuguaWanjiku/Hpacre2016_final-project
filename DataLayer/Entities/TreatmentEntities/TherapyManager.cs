using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.TreatmentEntities {
    public class TherapyManager {

        [Key]
        public int TherapyManager_id {
            get; set;
        }

        public virtual List<Therapy> Therapies {
            get; set;
        }
        /// <summary>
        /// Navigation prop
        /// </summary>
        public ClinicRegistryManager ClinicRegistryManager_Therapy { get; set; }
    }
}
