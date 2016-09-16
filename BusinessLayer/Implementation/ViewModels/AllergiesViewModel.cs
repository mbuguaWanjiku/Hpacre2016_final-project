using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation.ViewModels {
    public class AllergiesViewModel {

        public Nullable<DateTime> Allergy_start_date {
            get; set;
        }

        public Nullable<DateTime> Allergy_end_date {
            get; set;
        }

        public string Allergy_Name {
            get; set;
        }
        public int allergyId { get; set; }
    }
}
