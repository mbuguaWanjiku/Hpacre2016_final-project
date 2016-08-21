using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.DiagnosisEntities
{
    public class CIDCode
    {

        [Key]
        public int CIDCOD_id
        {
            get; set;
        }

        public string Version
        {
            get; set;
        }
        public virtual CID_DiseaseCode CID_DiseaseCode
        {
            get; set;
        }


    }
}
