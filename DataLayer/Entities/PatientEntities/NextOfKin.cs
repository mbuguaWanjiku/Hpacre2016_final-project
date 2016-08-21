using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataLayer.Entities.UserEntities;

namespace DataLayer.Entities.PatientEntities {
    public class NextOfKin : Person {

        public NOFkinRelationShip nextOfKin_relationship {
            get; set;
        }

        /// <summary>
        /// Navigation prop
        /// </summary>
        public virtual NextOfKinManager Next_of_kin_manager {
            get; set;
        }

    }
}
