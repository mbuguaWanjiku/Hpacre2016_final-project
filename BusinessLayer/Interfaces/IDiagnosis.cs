using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.DiagnosisEntities;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    interface IDiagnosis
    {
        //void InsertDiagnosis(string diseaseCategory, string diseaseCode);
        void SaveDiagnosis(List<CID_DiseaseCode> classifications);
        string DeactivateDisease(Disease disease);
        List<Disease> getPatientActiveDiseases(Patient patient);
        List<Disease> getPatientInActiveDiseases(Patient patient);
    }
}
