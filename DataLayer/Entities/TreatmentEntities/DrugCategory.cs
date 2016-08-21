using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.TreatmentEntities {
    public class DrugCategory {
        [Key]
        public int category_id {
            get; set;
        }
        public string description {
            get; set;
        }
        /// <summary>
        /// Every class have different medications
        /// </summary>
        public List<Drug> classDrugs {
            get; set;
        }
    }
}