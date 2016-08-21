using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataLayer.Entities.PatientEntities
{
    public class Intervention
    {

        [Key]
        public int Intervention_id
        {
            get; set;
        }

        public DateTime endsAt
        {
            get; set;
        }

        public DateTime startsAt
        {
            get; set;
        }

        public virtual TreatmentType Treatment_type
        {
            get; set;
        }
        /// <summary>
        /// navigation prop
        /// </summary>
        public virtual TreatmentPlan Treatment { get; set; }

    }
}
