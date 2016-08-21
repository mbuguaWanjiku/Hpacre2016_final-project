using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities.MCDT {
    public class PsychiatricExam : MCDT{

     /*   [Key]
        public int PsychiatricExam_id {
            get; set;
        */

        public string Observations {
            get; set;
        }

        /// <summary>
        /// Fazer enum 
        /// </summary>
        public string Humor {
            get; set;
        }

        /// <summary>
        /// Fazer enum 
        /// </summary>
        public string Cognition {
            get; set;
        }

        /// <summary>
        /// Fazer enum 
        /// </summary>
        public string Perception {
            get; set;
        }

        /// <summary>
        /// Fazer enum 
        /// </summary>
        public string Thoughts {
            get; set;
        }

        /// <summary>
        /// Fazer enum 
        /// </summary>
        public string Behavior {
            get; set;
        }

    }
}
