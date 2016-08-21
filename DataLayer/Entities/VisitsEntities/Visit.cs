using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Visitas {
    public class Visit {

        [Key]
        public int Visit_id {
            get; set;
        }

        public DateTime Visit_Date {
            get; set;
        }

        public DateTime Visit_Hour {
            get; set;
        }
       
       
    }
}
