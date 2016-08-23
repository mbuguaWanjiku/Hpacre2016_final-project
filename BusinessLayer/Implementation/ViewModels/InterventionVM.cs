using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation {/// <summary>
/// View model class
/// </summary>
    public class InterventionVM {

        public int Intervention_id {
            get; set;
        }

        public DateTime endsAt {
            get; set;
        }

        public DateTime startsAt {
            get; set;
        }

        public int Intervention_type_id {
            get; set;
        }

        public string Intervention_type_description {
            get; set;
        }

        public int TreatmentPlan {
            get; set;
        }
        
    }
}