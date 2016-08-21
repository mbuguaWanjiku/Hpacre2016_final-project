using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.Visitas {
    public class FirstVisit : Visit{

       
        public ClinicRegistryManager ClinicRegistry_Manager
        {
            get; set;
        }

    }
}
