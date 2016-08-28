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
    public class ImpMCDTs : IMCDTs {
        private HPCareDBContext db = new HPCareDBContext();

        public ImpMCDTs() {

        }

        public void SavePrescribedMCDT(List<string> listPrsecribedMCDT) {

            MCDT newUnregularMcdt;
            LabExams labExam;
            foreach(string mcdt in listPrsecribedMCDT) {
                if(mcdt.Equals("Physical")) {
                    newUnregularMcdt = new PhysicalExam { MCDT_date = DateTime.Now };
                    CreateMCDT(newUnregularMcdt);
                } else if(mcdt.Equals("Pyschiatric")) {
                    newUnregularMcdt = new PsychiatricExam { MCDT_date = DateTime.Now };
                    CreateMCDT(newUnregularMcdt);
                } else if(mcdt.Equals("KFT")) {
                    labExam = db.LabExams.Add(new KFT { MCDT_date = DateTime.Now, MCDT_type = MCDTType.KFT });
                    CreateMCDT(labExam);
                } else if(mcdt.Equals("LFT")) {
                    labExam = db.LabExams.Add(new KFT { MCDT_date = DateTime.Now, MCDT_type = MCDTType.LFT });
                    CreateMCDT(labExam);
                } else if(mcdt.Equals("LymphocytesSubsets")) {
                    labExam = db.LabExams.Add(new LymphocytesSubsets { MCDT_date = DateTime.Now, MCDT_type = MCDTType.LymphocytesSubsets });
                    CreateMCDT(labExam);
                } else if(mcdt.Equals("RBCS")) {
                    labExam = db.LabExams.Add(new RBCS { MCDT_date = DateTime.Now, MCDT_type = MCDTType.RBCS });
                    CreateMCDT(labExam);
                } else if(mcdt.Equals("PlateletsCount")) {
                    labExam = db.LabExams.Add(new PlateletsCount { MCDT_date = DateTime.Now, MCDT_type = MCDTType.PlateletsCount });
                    CreateMCDT(labExam);
                } else if(mcdt.Equals("RBCIndices")) {
                    labExam = db.LabExams.Add(new RBCIndices { MCDT_date = DateTime.Now, MCDT_type = MCDTType.RBCIndices });
                    CreateMCDT(labExam);
                } else if(mcdt.Equals("WBCS")) {
                    labExam = db.LabExams.Add(new WBCS { MCDT_date = DateTime.Now, MCDT_type = MCDTType.WBCS }) as WBCS;
                    CreateMCDT(labExam);
                } else if(mcdt.Equals("ViralLoad")) {
                    labExam = db.LabExams.Add(new ViralLoad { MCDT_date = DateTime.Now, MCDT_type = MCDTType.ViralLoad });
                    CreateMCDT(labExam);
                }

            }


            //LabExams  lab=  db.LabExams.Add(e);
            //CreateMCDT(lab);
        }


        /// <summary>
        /// first step --add mcdt
        /// second step- add mcdt_staff_manager considering null staff
        /// third step- add mcdt-staff-manager to the MCDT manager
        /// </summary>
        /// <param name="mcdt"></param>
        private void CreateMCDT(MCDT mcdt) {

            MCDTStaffManager MCDT_staffManager = db.MCDTStaffManagers.Add(new MCDTStaffManager { mcdt = mcdt });

            MCDTManager mcdtManager = db.MCDTManagers.Add(
                new MCDTManager { MCDTStaffManager = MCDT_staffManager, clinicRegistryManager = SingletonClinicRegistry.GetInstance(db) });

            db.SaveChanges();

        }
    }

}
