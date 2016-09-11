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

        /// <summary>
        /// Saves the diagnosis.
        /// </summary>
        /// <param name="classifications">The classifications.</param>
        void SaveDiagnosis(List<CID_DiseaseCode> classifications);
        string DeactivateDisease(int diseaseId);
       
    }
}
