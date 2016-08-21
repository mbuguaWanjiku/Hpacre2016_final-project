using DataLayer.Entities.TreatmentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    interface IMedication
    {
        void savePrescribedMedication(List<DrugIssuance> prescibedMedication);
    }
}
