using DataLayer.Entities.VisitsEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Visitas {
    /// <summary>
    /// unused
    /// </summary>
    public class VisitManager {

        [Key]
        public int VisitManager_id {
            get; set;
        }

        public Visit visit {
            get; set;
        }

        public Patient patient {
            get; set;
        }

        public ClinicRegistryManager PatientVisitRegistry {
            get; set;
        }

        public virtual Registry VisitRegistry {
            get; set;
        }
    }

}
