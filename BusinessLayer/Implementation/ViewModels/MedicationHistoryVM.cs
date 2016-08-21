using DataLayer.Entities.TreatmentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    public class MedicationHistoryVm
    {
        public int Issance_ID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DrugName { get; set; }
        public string Drugcategory { get; set; }
    }
}
