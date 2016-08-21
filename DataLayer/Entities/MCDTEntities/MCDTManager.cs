using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class MCDTManager {

        [Key]
        public int MCDTManager_id {
            get; set;
        }

        /// <summary>
        /// UM MCDT pode ser realizado pelo mais de um staff
        /// </summary>
        public virtual MCDTStaffManager MCDTStaffManager {
            get; set;
        }
        /// <summary>
        /// nav prop
        /// </summary>

        public virtual ClinicRegistryManager clinicRegistryManager {
            get; set;
        }


    }
}
