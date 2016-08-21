using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.TreatmentEntities
{
    public class DrugAdministration
    {
        [Key]
        public int Administration_Id { get; set; }
        public string Description { get; set; }
        //Oral,
        //Intramuscular,
        //Intravenous
    }
}
