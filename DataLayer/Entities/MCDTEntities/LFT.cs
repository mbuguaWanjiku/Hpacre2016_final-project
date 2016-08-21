using System;using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class LFT : LabExams {

   /*     [Key]
        public int LFT_id {
            get; set;
        }
        */
        public Nullable<double> SGT {
            get; set;
        }

        public Nullable<double> AST {
            get; set;
        }

        public Nullable<double> LDH {
            get; set;
        }

        public Nullable<double> Alkaline {
            get; set;
        }

        public Nullable<double> Bilirubin {
            get; set;
        }

    }
}
