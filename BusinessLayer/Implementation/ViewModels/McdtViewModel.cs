using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation.ViewModels {
    public class McdtViewModel {

        public int McdtId {
            get; set;
        }

        public string UserName {
            get; set;
        }

        public int UserId {
            get; set;
        }

        public int McdtType {
            get; set;
        }

        public DateTime McdtDate {
            get; set;
        }

        public DateTime LabDateIn {
            get; set;
        }

        public DateTime LabDateOut {
            get; set;
        }

        public string Discriminator {
            get; set;
        }

    }
}
