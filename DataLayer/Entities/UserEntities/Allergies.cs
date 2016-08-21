using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
    public class Allergies {

        [Key]
        public int Allergy_id {
            get; set;
        }

        public string Allergy_Name {
            get; set;
        }

        public AllergyCategory AllergyCategory {
            get; set;
        }

        ///// <summary>
        ///// navigation prop
        ///// </summary>
        //public virtual AllergiesManager Allergies_AllergyManager {
        //    get; set;
        //}

    }
}
