using DataLayer.Entities.TreatmentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation
{
    interface ITherapy
    {
        void SaveTherapies(List<Therapy> prescribedTherapies);
    }
}
