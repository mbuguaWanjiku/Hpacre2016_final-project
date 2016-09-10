using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation {
    public class PatientDiseaseHistoryVM {
        public DateTime StartDate {
            get; set;
        }

        public DateTime EndDate {
            get; set;
        }

        public string DiseaseCIDCategory {
            get; set;
        }
        public string DiseaseCIDCode {
            get; set;
        }
        public string Version {
            get; set;
        }
        public string PhysicianName {
            get; set;
        }
        public int Disease_id
        {
            get; set;
        }
    }
}
