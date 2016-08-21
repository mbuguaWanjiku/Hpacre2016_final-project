using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.PatientEntities
{
   public class TreatmentCategory
    {
        public int id { get; set; }
        public string Description { get; set; }
        public virtual List<TreatmentType> TreatmentCategories { get; set; }
    }
}
