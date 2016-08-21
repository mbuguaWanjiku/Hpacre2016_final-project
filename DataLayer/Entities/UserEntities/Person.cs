using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.UserEntities {
    public class Person {
        [Key]
        public int personId {
            get; set;
        }
        public string Name {
            get; set;
        }

        public string Address {
            get; set;
        }

        public string Telephone {
            get; set;
        }

        public string Email {
            get; set;
        }
    }
}
