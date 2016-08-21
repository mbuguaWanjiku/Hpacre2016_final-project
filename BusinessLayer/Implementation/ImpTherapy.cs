using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.TreatmentEntities;
using DataLayer.EntityFramework;

namespace BusinessLayer.Implementation {
    public class ImpTherapy : ITherapy {
        private HPCareDBContext context;
        public ImpTherapy(HPCareDBContext context) {
            this.context = context;
        }
        public void SaveTherapies(List<Therapy> prescribedTherapies) {
            TherapyManager therapyManager = new TherapyManager();//incomplete--clinical registry
            foreach(Therapy therapy in prescribedTherapies) {
                therapy.TherapyManager = therapyManager;
                context.Therapies.Add(therapy);
            }
            context.SaveChanges();
        }
    }
}
