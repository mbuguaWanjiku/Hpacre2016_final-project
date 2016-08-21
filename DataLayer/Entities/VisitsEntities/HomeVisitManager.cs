using DataLayer.Entities.MCDT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Visits {
    /// <summary>
    /// unused
    /// </summary>
    public class HomeVisitManager {

        [Key]
        public int HomeVisitManager_id {
            get; set;
        }
        public  HomeVisit home_Visit
        {
            get; set;
        }
        /// <summary>
        /// um visita pode ter mais de um staff
        /// </summary>
        public List<Staff> staff_homeVisit
        {
            get; set;
        }
       
    }
}
