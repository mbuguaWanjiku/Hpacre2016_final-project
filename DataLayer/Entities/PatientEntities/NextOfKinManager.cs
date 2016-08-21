using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataLayer.Entities.PatientEntities {
    public class NextOfKinManager {

        [Key]
        public int NextOfKinManager_id {
            get; set;
        }

        public virtual List<NextOfKin> Next_of_kin {
            get; set;
        }


    }
}
