using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.DiagnosisEntities {
    public class CID_Category {
        [Key]
        public int CID_CategorID {
            get; set;
        }

        public string Description {
            get; set;
        }

        public virtual List<CID_DiseaseCode> CID_number {
            get; set;
        }
    }

}