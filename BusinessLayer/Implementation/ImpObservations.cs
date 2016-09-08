using BusinessLayer.Implementation.ViewModels;
using DataLayer.Entities;
using DataLayer.Entities.Visitas;
using DataLayer.Entities.VisitsEntities;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.Implementation
{
    public class ImpObservations
    {
        HPCareDBContext db;
        public ImpObservations(HPCareDBContext db)
        {
            this.db = db;
        }

        public void SaveObservation(List<string> observationList)
        {
            db.Observations.Add(new Observations
            {
                subject = observationList[0],
                ObservationBody = observationList[1],
                clinicalRegistry = SingletonClinicRegistry.GetInstance(db)
            });
            db.SaveChanges();
        }

        //    public List<GetObservation()
        //    {
        //        throw new NotImplementedException();
        //}
        private List<ClinicRegistryManager> GetPatientClinicalRegisties()
        {
            Patient patient = db.Users.Find(HttpContext.Current.Session["patientId"]) as Patient;
            List<ClinicRegistryManager> clinicalRegistries =
                db.ClinicRegistryManagers.Where(x => x.Clinic_patient.User_id == patient.User_id).ToList();
            return clinicalRegistries;
        }
        public List<ObservationsVM> GetObservations()
        {
            List<ObservationsVM> listVm = new List<ObservationsVM>();
            foreach (ClinicRegistryManager reg in GetPatientClinicalRegisties())
            {
               
                    listVm.Add(GetObservationVM(reg));
                
            }
            return listVm;
        }
        private ObservationsVM GetObservationVM(ClinicRegistryManager registry)
        {
            ObservationsVM vm = null;
            VisitManager vManager = null;
            List<Observations> obs = db.Observations.Where(x => x.clinicalRegistry.ClinicRegistryManagerId == registry.ClinicRegistryManagerId).ToList();
            int c = obs.Count;
            foreach (Observations item in obs)
            {
                vManager = db.VisitManagers.Where(x => x.PatientVisitRegistry.ClinicRegistryManagerId == registry.ClinicRegistryManagerId).FirstOrDefault();

                if (!vManager.Equals(null))
                {
                    vm = new ObservationsVM();
                    vm.Subject = item.subject;
                    vm.observationID = item.observations_ID;
                    vm.Date = vManager.visit.Visit_Date;
                    vm.Author = db.ClinicRegistryManagers.Where(x => x.ClinicRegistryManagerId == registry.ClinicRegistryManagerId).FirstOrDefault().Staff_doctor.Name;
                }
            }

            return vm;
        }

    }
}
