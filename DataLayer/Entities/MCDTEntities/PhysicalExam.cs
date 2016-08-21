using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class PhysicalExam : MCDT {

     /*   [Key]
        public int PhysicalExam_id {
            get; set;
        }*/

        public float Height {
            get; set;
        }

        public float Weigth {
            get; set;
        }

        public int Blood_pressure {
            get; set;
        }

        public float Body_temperature {
            get; set;
        }
    }
}
