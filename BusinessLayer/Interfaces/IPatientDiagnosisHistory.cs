using BusinessLayer.Implementation;
using DataLayer.Entities;
using DataLayer.Entities.DiagnosisEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces {
    interface IPatientDiagnosisHistory {
        List<PatientDiseaseHistoryVM> GetPatientDiseases(Patient patient);

    }
}
