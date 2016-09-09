using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.UserEntities {
    public class Photo {

        [Key]
        public int PhotoId {
            get; set;
        }

        public string PhotoPath {
            get; set;
        }

        public Users PatientId {
            get; set;
        }

    }
}
