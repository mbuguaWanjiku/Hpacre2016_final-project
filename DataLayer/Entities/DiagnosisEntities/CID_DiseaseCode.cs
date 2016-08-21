using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.DiagnosisEntities {
    public class CID_DiseaseCode {

        [Key]
        public int DiseaseCID_ID {
            get; set;
        }


        public string DiseaseCode {
            get; set;
        }
        /// <summary>
        /// nav prop
        /// </summary>
        public virtual CID_Category CIDCategory {
            get; set;
        }
    }
}
