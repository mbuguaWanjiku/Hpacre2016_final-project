using BusinessLayer.Interfaces;
using DataLayer.Entities;
using DataLayer.Entities.PatientEntities;
using DataLayer.Entities.Visitas;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Implementation
{/// <summary>
/// This class configures patient's treatment plan
/// </summary>
    public class ImpTreatmentPlan : ITreatmentPlan
    {
        private HPCareDBContext db;
        private Patient patient;
        public ImpTreatmentPlan(HPCareDBContext db)
        {
            patient = db.Users.Find(HttpContext.Current.Session["patientId"]) as Patient;
            this.db = db;
        }
        /// <summary>
        /// adds an intervention to a new treatment plan or existing one
        /// </summary>
        public void AddIntervention()
        {
            if (existPlan())
            {
                AddNewIntervention();
            }
            else
            {
                CreateNewTreatmentPlan();
            }
            db.SaveChanges();
        }

        /// <summary>
        /// check the patient have an existing treatment plan
        /// </summary>
        /// <returns></returns>
        public bool existPlan()
        {
            int count = db.TreatmentPlans.Where(x => x.Patient_TreatmentPlan.User_id == patient.User_id).Count();
            return (count > 1);
        }
        /// <summary>
        /// If the patieny is not associated to any plan a new one is created
        /// ordem title, startsAt, endsAt
        /// </summary>
        /// <param name="intervention"></param>
        private void CreateNewTreatmentPlan()
        {
            TreatmentPlan plan = new TreatmentPlan { Patient_TreatmentPlan = patient };
            TreatmentType typeDefault = db.TreatmentTypes.Where(x => x.Description == "unset").FirstOrDefault();
            db.Interventions.Add(new Intervention { Treatment = plan, Treatment_type = typeDefault, startsAt = DateTime.Now, endsAt = DateTime.Now });
            db.SaveChanges();
        }/// <summary>
        /// au auxilliary function which adds a default intervention type
        /// </summary>
        private void AddNewIntervention()
        {
            TreatmentPlan plan = db.TreatmentPlans.Where(x => x.Patient_TreatmentPlan.User_id == patient.User_id).FirstOrDefault();
            TreatmentType typeDefault = db.TreatmentTypes.Where(x => x.Description == "unset").FirstOrDefault();
            db.Interventions.Add(new Intervention { Treatment = plan, Treatment_type = typeDefault, startsAt = DateTime.Now, endsAt = DateTime.Now });
            db.SaveChanges();
        }
        /// <summary>
        /// if the logged user is patient the instance is obtained from the logged user identity otherwise from the session
        /// </summary>
        /// <param name="logged">user instance</param>
        /// <returns>Intervention view model data-startdate,enddate,typeID and description</returns>
        public List<InterventionVM> GetInterventions(Users logged)
        {
            if(logged.UserType == 4)
            {
                patient = logged as Patient;
            }
            //ClinicRegistryManager registry = SingletonClinicRegistry.GetInstance(db);
            
            List<Intervention> list =
              db.Interventions.Where(x => x.Treatment.Patient_TreatmentPlan.User_id == patient.User_id).ToList();//use session value
            List<InterventionVM> listInterventions = new List<InterventionVM>();
            InterventionVM vm;
            int c = list.Count;
            foreach (Intervention inter in list)
            {
                vm = new InterventionVM();
                vm.Intervention_id = inter.Intervention_id;
                vm.startsAt = inter.startsAt;
                vm.endsAt = inter.endsAt;
                vm.Intervention_type_id = inter.Treatment_type.id;
                vm.Intervention_type_description = inter.Treatment_type.Description;
                listInterventions.Add(vm);

            }

            return listInterventions;

        }
        /// <summary>
        /// Retrieves the treatmentType associated to the category
        /// </summary>
        /// <param name="id">categoryid</param>
        /// <returns>treatement  type</returns>
        public List<TreatmentTypeVM> getTreatmentType(int id)
        {
            List<TreatmentType> listType = db.TreatmentTypes.Where(x => x.TreatmentCategory.id == id).ToList();
            int X = listType.Count + 1;
            List<TreatmentTypeVM> listTypeAux = new List<TreatmentTypeVM>();
            TreatmentTypeVM aux;
            foreach (TreatmentType item in listType)
            {
                aux = new TreatmentTypeVM();
                aux.id = item.id;
                aux.Description = item.Description;
                listTypeAux.Add(aux);
            }
            return listTypeAux;
        }
        /// <summary>
        /// set categories view model
        /// </summary>
        /// <returns>treatment category viewmodel</returns>
        public List<TreatmentCategoryVM> getTreatmentTypeCategories()
        {
            List<TreatmentCategory> listCat = db.TreatmentCategories.ToList();
            //removing the default category-unset
            listCat.Remove(db.TreatmentCategories.Where(x => x.Description == "unset").FirstOrDefault());
            List<TreatmentCategoryVM> listCatVM = new List<TreatmentCategoryVM>();
            TreatmentCategoryVM aux;
            foreach (TreatmentCategory item in listCat)
            {
                aux = new TreatmentCategoryVM();
                aux.id = item.id;
                aux.Description = item.Description;
                listCatVM.Add(aux);
            }

            return listCatVM;
        }
        /// <summary>
        /// save the list of interventions
        /// </summary>
        /// <param name="interventions">list of interventions objects</param>
        public void SaveInterventions(List<string> interventions)
        {
            TreatmentPlan treatmentPlan = new TreatmentPlan { Patient_TreatmentPlan = patient };
            int intervention_id = 0;
            int id = 0;
            Int32.TryParse(interventions[0], out id);
            Int32.TryParse(interventions[3], out intervention_id);
            DateTime start = Convert.ToDateTime(interventions[1]);
            DateTime end = Convert.ToDateTime(interventions[2]);
            TreatmentType type = db.TreatmentTypes.Find(id);
            //Intervention newIntervention = new Intervention {startsAt = start ,endsAt = end,Treatment_type = type,Treatment = treatmentPlan };
            //db.Interventions.Add(newIntervention);
            Intervention updateIntervention = db.Interventions.Find(intervention_id);
            updateIntervention.endsAt = end;
            updateIntervention.startsAt = start;
            updateIntervention.Treatment_type = type;
            db.SaveChanges();
        }
        /// <summary>
        /// deletes the intervention identified by id
        /// </summary>
        /// <param name="id">Intervention id</param>
        public void DeleteIntervention(int id)
        {
            db.Interventions.Remove(db.Interventions.Find(id));
            db.SaveChanges();
        }
    }
}



