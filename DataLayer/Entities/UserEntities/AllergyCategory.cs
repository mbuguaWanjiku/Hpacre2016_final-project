using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities {
   public class AllergyCategory {

        [Key]
        public int AllergyCategoryId {
            get; set;
        }

        public string AllergyCategoryName {
            get; set;
        }

    }
}
