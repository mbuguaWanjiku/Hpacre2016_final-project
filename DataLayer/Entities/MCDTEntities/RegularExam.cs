using DataLayer.Entities.MCDT;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDTEntities {
    public class RegularExam {

        [Key]
        public int RegularExam_id {
            get; set;
        }

        public KFT KFT_exam {
            get; set;
        }

        public LFT LFT_exam {
            get; set;
        }

        public LymphocytesSubsets Lymphocytes_exam {
            get; set;
        }

        public PlateletsCount Platelets_exam {
            get; set;
        }

        public RBCIndices RBCIndeces_exam {
            get; set;
        }

        public RBCS RBCS_exam {
            get; set;
        }

        public WBCS WBCS_exam {
            get; set;
        }

        public ViralLoad ViralLoad_Exam {
            get; set;
        }

    }
}
