using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation.ViewModels
{
  public  class ObservationsVM
    {
        public int observationID { get; set; }
        public string Subject { get; set; }
        public string Author { get; set; }
        public DateTime? Date { get; set; }
    }
}
