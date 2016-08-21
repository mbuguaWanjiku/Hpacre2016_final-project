using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.Entities {
    public class AgeGroup {

        [Key]
        public int AgeGroup_id {
            get; set;
        }

        /// <summary>
        /// Vai ser inserido através de trigger
        /// 0-17 Criança
        /// 18-64 Adulto
        /// 65+ Idoso
        /// </summary>
        public string Description {
            get; set;
        }

      

    }
}
