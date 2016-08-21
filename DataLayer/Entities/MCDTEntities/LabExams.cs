using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class LabExams : MCDT {

        //[Key]
        //public int LabExams_id {
        //    get; set;
        //}

        public Nullable<DateTime> LabExam_data_in {
            get; set;
        }

        public Nullable<DateTime> LabExam_date_out {
            get; set;
        }
    }
}
