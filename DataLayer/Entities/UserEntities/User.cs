using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataLayer.Entities.UserEntities;

namespace DataLayer.Entities {
    public abstract class Users {
        [Key]
        public int User_id {
            get; set;
        }

        public string Password {
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

        public Gender gender {
            get; set;
        }

        public MaritalStatus MaritalStatus {
            get; set;
        }

        public int AspUserId {
            get; set;
        }
        
        public int UserType {
            get; set;
        }

        public string User_identification {
            get; set;
        }

    }
}
