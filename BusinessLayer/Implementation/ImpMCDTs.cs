using BusinessLayer.Interfaces;
using DataLayer.Entities.MCDT;
using DataLayer.Entities.MCDTEntities;
using DataLayer.Entities.Visitas;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementation {
    /// <summary>
    /// This class save the prescibed MCDTS
    /// </summary>
    public class ImpMCDTs : IMCDTs {
        private HPCareDBContext db ;

        public ImpMCDTs(HPCareDBContext db) {
            this.db = new HPCareDBContext();
        }
        /// <summary>
        /// Creates an instance of a specific mcdt ,associates it with the current date and 
        /// save to database by calling the auxilliary function below
        /// </summary>
        /// <param name="listPrsecribedMCDT">list of prescribed mcdts</param>
        public void SavePrescribedMCDT(List<string> listPrsecribedMCDT) {

            MCDT newUnregularMcdt;
            LabExams labExam;
            foreach(string mcdt in listPrsecribedMCDT) {
                if(mcdt.Equals("Physical")) {
                    newUnregularMcdt = new PhysicalExam { MCDT_date = DateTime.Now };
                    SavePrescribedMcdtAUX(newUnregularMcdt);
                } else if(mcdt.Equals("Pyschiatric")) {
                    newUnregularMcdt = new PsychiatricExam { MCDT_date = DateTime.Now };
                    SavePrescribedMcdtAUX(newUnregularMcdt);
                } else if(mcdt.Equals("KFT")) {
                    labExam = new KFT { MCDT_date = DateTime.Now, MCDT_type = MCDTType.KFT };
                    SavePrescribedMcdtAUX(labExam);
                } else if(mcdt.Equals("LFT")) {
                    labExam = new LFT { MCDT_date = DateTime.Now, MCDT_type = MCDTType.LFT };
                    SavePrescribedMcdtAUX(labExam);
                } else if(mcdt.Equals("LymphocytesSubsets")) {
                    labExam = new LymphocytesSubsets { MCDT_date = DateTime.Now, MCDT_type = MCDTType.LymphocytesSubsets };
                    SavePrescribedMcdtAUX(labExam);
                } else if(mcdt.Equals("RBCS")) {
                    labExam = new RBCS { MCDT_date = DateTime.Now, MCDT_type = MCDTType.RBCS };
                    SavePrescribedMcdtAUX(labExam);
                } else if(mcdt.Equals("PlateletsCount")) {
                    labExam = new PlateletsCount { MCDT_date = DateTime.Now, MCDT_type = MCDTType.PlateletsCount };
                    SavePrescribedMcdtAUX(labExam);
                } else if(mcdt.Equals("RBCIndices")) {
                    labExam = new RBCIndices { MCDT_date = DateTime.Now, MCDT_type = MCDTType.RBCIndices };
                    SavePrescribedMcdtAUX(labExam);
                } else if(mcdt.Equals("WBCS")) {
                    labExam = new WBCS { MCDT_date = DateTime.Now, MCDT_type = MCDTType.WBCS };
                    SavePrescribedMcdtAUX(labExam);
                } else if(mcdt.Equals("ViralLoad")) {
                    labExam = new ViralLoad { MCDT_date = DateTime.Now, MCDT_type = MCDTType.ViralLoad };
                    SavePrescribedMcdtAUX(labExam);
                }

            }


            //LabExams  lab=  db.LabExams.Add(e);
            //CreateMCDT(lab);
        }


        /// <summary>
        /// first step --add mcdt
        /// second step- add mcdt_staff_manager considering null staff to be later filled by labTec
        /// third step- add mcdt-staff-manager to the MCDT manager
        /// </summary>
        /// <param name="mcdt"></param>
        private void SavePrescribedMcdtAUX(MCDT mcdt) {

            MCDTStaffManager MCDT_staffManager = db.MCDTStaffManagers.Add(new MCDTStaffManager { mcdt = mcdt });

            MCDTManager mcdtManager = db.MCDTManagers.Add(
                new MCDTManager { MCDTStaffManager = MCDT_staffManager, clinicRegistryManager = SingletonClinicRegistry.GetInstance(db) });

            db.SaveChanges();

        }
    }

}
