using DataLayer.Entities.MCDT;
using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    public class Staff : Users {

        /*public string Designation {
            get; set;
        }*/



        public ProfessionalsType ProfessionalType {
            get; set;
        }
        ///// <summary>
        ///// Navigation prop
        ///// </summary>
        //public virtual MCDTStaffManager MCDTStaffManager {
        //    get; set;
        //}
        /// <summary>
        /// Navigation prop
        /// </summary>


    }
}
