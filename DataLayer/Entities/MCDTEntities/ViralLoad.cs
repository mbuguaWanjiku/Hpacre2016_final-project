using DataLayer.Entities.MCDT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDTEntities {
    public class ViralLoad : LabExams {

        /*  [Key]
          public int Viral_load_id {
              get; set;
          }*/

        public Nullable<double> value {
            get; set;
        }
    }
}
