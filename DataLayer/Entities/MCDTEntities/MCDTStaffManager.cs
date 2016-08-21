using DataLayer.Entities.Visits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class MCDTStaffManager {

        [Key]
        public int MCDTStaffManager_id {
            get; set;
        }

        public MCDT mcdt {
            get; set;
        }
        /// <summary>
        /// staff que realiza mcdt
        /// </summary>
        public Staff Staff {
            get; set;
        }
        /**
        *navigation prop
        */


       
    }
}
