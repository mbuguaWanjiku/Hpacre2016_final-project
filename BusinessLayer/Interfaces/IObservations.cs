using BusinessLayer.Implementation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    interface IObservations
    {
        void SaveObservation(List<string> observationList);
        List<ObservationsVM> GetObservations();
    }
}
