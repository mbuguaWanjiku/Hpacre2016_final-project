using DataLayer.Entities.MCDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation.ViewModels {
    public class RegularExamsVM {
        public int Mcdt_id {
            get; set;
        }
        public DateTime MCDT_date {
            get; set;
        }
        public Nullable<DateTime> LabExam_data_in {
            get; set;
        }
        public Nullable<DateTime> LabExam_data_out {
            get; set;
        }
        public int MCDT_units_Id {
            get; set;
        }
        public string Staff_User_id {
            get; set;
        }
        public string Discriminator {
            get; set;
        }
        //    public MCDT mcdt { get; set; }
    }
}
