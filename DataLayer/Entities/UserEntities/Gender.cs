using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.UserEntities {

    public class Gender {

        [Key]
        public int GenderId {
            get; set;
        }

        public string GenderName {
            get; set;
        }

    }
}
//public enum Gender {

//    male, female


//}