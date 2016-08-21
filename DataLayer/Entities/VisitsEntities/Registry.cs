using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.VisitsEntities {
    public class Registry {

        public int Id {
            get; set;
        }

        public List<VisitManager> PatientVisitsRegistry {
            get; set;
        }
    }
}
