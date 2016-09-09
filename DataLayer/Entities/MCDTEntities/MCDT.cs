using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataLayer.Entities.MCDTEntities;

namespace DataLayer.Entities.MCDT {
    public abstract class MCDT {

        [Key]
        public int MCDT_ID {
            get; set;
        }

        public Units MCDT_units {
            get; set;
        }

        //public string Name {
        //    get; set;
        //}

        public MCDTType MCDT_type {
            get; set;
        }

        public Nullable<DateTime> MCDT_date {
            get; set;
        }

        /* public MCDTManager MCDT_Manager {
             get; set;
         }*/
    }
}
