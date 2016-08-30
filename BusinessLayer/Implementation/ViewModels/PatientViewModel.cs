using DataLayer.Entities;
using DataLayer.Entities.PatientEntities;
using DataLayer.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation.ViewModels {
    public class PatientViewModel {

        public AgeGroup Patient_Age_Group {
            get; set;
        }

        public List<string> RiskFactorManager {
            get; set;
        }

        public List<string> AllergiesManager {
            get; set;
        }

        public List<string> FamilyHistoryManager {
            get; set;
        }

        public NextOfKin Patient_next_of_kin {
            get; set;
        }

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
