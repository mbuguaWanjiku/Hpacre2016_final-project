using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
   
    interface IMCDTs
    {
      void  SavePrescribedMCDT(List<string> listPrsecribedMCDT);
    }
}
