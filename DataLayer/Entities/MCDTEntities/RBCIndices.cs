using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class RBCIndices : LabExams{

     /*   [Key]
        public int RBCIndixes_id {
            get; set;
        }*/

        public Nullable<double> MCH {
            get; set;
        }

        public Nullable<double> MCHC {
            get; set;
        }

        public Nullable<double> MCV {
            get; set;
        }

        public Nullable<double> Amylase {
            get; set;
        }

        public Nullable<double> Cholesterol {
            get; set;
        }

        public Nullable<double> CPK {
            get; set;
        }

        public Nullable<double> Globulin {
            get; set;
        }

    }
}
