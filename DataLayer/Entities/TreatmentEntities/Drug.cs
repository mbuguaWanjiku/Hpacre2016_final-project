using DataLayer.Entities.PatientEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataLayer.Entities.TreatmentEntities
{
    public class Drug
    {

        [Key]
        public int Drug_id
        {
            get; set;
        }

        public string Drug_name
        {
            get; set;
        }
        /// <summary>
        /// Navigation prop
        /// Every drug have a category/class
        /// </summary>
        public DrugCategory Category { get; set; }
    }
}
