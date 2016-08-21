using DataLayer.Entities.MCDT;
using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Visits {
    public class HomeVisit : Visit {

   
        /// <summary>
        /// physicalExam and psychiatricExam
        /// </summary>
        public List <MCDTStaffManager> homeMcdtStaffManager
        {
            get; set;
        }
    }
}
