using BusinessLayer.Implementation;
using DataLayer.Entities.PatientEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces {
    public interface ITreatmentPlan {

        List<TreatmentCategoryVM> getTreatmentTypeCategories();
        List<TreatmentTypeVM> getTreatmentType(int id);
        void SaveInterventions(List<string> interventions);
        List<InterventionVM> GetInterventions();
        void AddIntervention();
        void DeleteIntervention(int id);
    }
}