using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class RBCS : LabExams{

      /*  [Key]
        public int RBCD_id {
            get; set;
        */

        public Nullable<double> HB {
            get; set;
        }

        public Nullable<double> HCT {
            get; set;
        }
    }
}
