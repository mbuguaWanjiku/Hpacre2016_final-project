using BusinessLayer.Implementation;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    interface ImedicationHistory
    {
        List<MedicationHistoryVm> GetPatientMedicationHistory();
    }
}
