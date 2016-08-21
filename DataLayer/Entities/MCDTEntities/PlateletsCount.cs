using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class PlateletsCount:LabExams {

  /*      [Key]
        public int PlateletsCount_id {
            get; set;
        }*/

        public Nullable<double> Count {
            get; set;
        }

    }
}
