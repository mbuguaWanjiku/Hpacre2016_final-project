using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.TreatmentEntities
{
  public  class Dosage
    {
        [Key]
        public int Dosage_id { get; set; }
        public string Description { get; set; }
    }
}
