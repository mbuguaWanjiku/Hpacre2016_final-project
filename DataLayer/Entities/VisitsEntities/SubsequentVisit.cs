using DataLayer.Entities.MCDTEntities;
using DataLayer.Entities.Visitas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Visits {
    public class SubsequentVisit : Visit{

        public ClinicRegistryManager ClinicRegistry_Manager
        {
            get; set;
        }
        public  RegularExam regularExam
        {
            get; set;
        }
    }
}
