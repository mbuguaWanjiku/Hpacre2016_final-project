using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.VisitsEntities
{
    public class Observations
    {
        [Key]
        public int observations_ID { get; set; }

        public string subject { get; set; }
        public string ObservationBody { get; set; }
        public ClinicRegistryManager clinicalRegistry { get; set; }

    }
}