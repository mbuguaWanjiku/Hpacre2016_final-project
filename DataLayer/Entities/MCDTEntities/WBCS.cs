using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class WBCS : LabExams{

        //[Key]
        //public int WBCS_id {
        //    get; set;
        //}

        public Nullable<double> Basophil {
            get; set;
        }

        public Nullable<double> Eosinophil {
            get; set;
        }

        public Nullable<double> Monocytes {
            get; set;
        }

        public Nullable<double> Neutrophil {
            get; set;
        }
    }
}
