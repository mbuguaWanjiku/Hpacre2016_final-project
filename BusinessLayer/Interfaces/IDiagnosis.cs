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
       
        void SaveDiagnosis(List<CID_DiseaseCode> classifications);
        string DeactivateDisease(int diseaseId);
       
    }
}
