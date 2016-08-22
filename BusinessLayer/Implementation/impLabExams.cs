using BusinessLayer.Interfaces;
using DataLayer.Entities.MCDT;
using DataLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities.MCDTEntities;
using BusinessLayer.Implementation.ViewModels;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace BusinessLayer.Implementation {
    public class impLabExams : ILabExams {

        private HPCareDBContext db;
        private List<McdtViewModel> listMcdtVM;

        public impLabExams(HPCareDBContext db) {
            this.db = db;
            listMcdtVM = new List<McdtViewModel>();
        }

        public void saveKft(List<KFT> kftList) {
            KFT kft = db.MCDTs.Find(kftList.Single().MCDT_ID) as KFT;
            kft.LabExam_data_in = DateTime.Now;

            foreach(KFT k in kftList) {
                kft.BUN = k.BUN;
                kft.Creatinine = k.Creatinine;
                kft.uricAcid = k.uricAcid;
                kft.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();
        }

        public void saveLft(List<LFT> lftList) {
            LFT lft = db.MCDTs.Find(lftList.First().MCDT_ID) as LFT;
            lft.LabExam_data_in = DateTime.Now;

            foreach(LFT l in lftList) {
                lft.Alkaline = l.Alkaline;
                lft.AST = l.AST;
                lft.Bilirubin = l.Bilirubin;
                lft.LDH = l.LDH;
                lft.SGT = l.SGT;
                lft.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();

        }

        public void saveLymphocyteSubsets(List<LymphocytesSubsets> lymList) {
            LymphocytesSubsets lymphocytes = db.MCDTs.Find(lymList.Single().MCDT_ID) as LymphocytesSubsets;
            lymphocytes.LabExam_data_in = DateTime.Now;

            foreach(LymphocytesSubsets l in lymList) {
                lymphocytes.CD3 = l.CD3;
                lymphocytes.CD4 = l.CD4;
                lymphocytes.CD8 = l.CD8;
                //lymphocytes.Lymphocytes_units = l.Lymphocytes_units;
                lymphocytes.T_lymphocytes = l.T_lymphocytes;
                lymphocytes.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();

        }

        public void savePlateletsCount(List<PlateletsCount> platList) {
            PlateletsCount platelets = db.MCDTs.Find(platList.Single().MCDT_ID) as PlateletsCount;
            platelets.LabExam_data_in = DateTime.Now;

            foreach(PlateletsCount p in platList) {
                platelets.Count = p.Count;
                platelets.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();
        }

        public void saveRbcIndices(List<RBCIndices> rbcIndicesList) {
            RBCIndices rbcIndices = db.MCDTs.Find(rbcIndicesList.Single().MCDT_ID) as RBCIndices;
            rbcIndices.LabExam_data_in = DateTime.Now;

            foreach(RBCIndices r in rbcIndicesList) {
                rbcIndices.Amylase = r.Amylase;
                rbcIndices.Cholesterol = r.Cholesterol;
                rbcIndices.CPK = r.CPK;
                rbcIndices.Globulin = r.Globulin;
                rbcIndices.MCH = r.MCH;
                rbcIndices.MCHC = r.MCHC;
                rbcIndices.MCV = r.MCV;
                rbcIndices.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();
        }

        public void saveRbcs(List<RBCS> rbcsList) {
            RBCS rbcs = db.MCDTs.Find(rbcsList.Single().MCDT_ID) as RBCS;
            rbcs.LabExam_data_in = DateTime.Now;

            foreach(RBCS r in rbcsList) {
                rbcs.HB = r.HB;
                rbcs.HCT = r.HCT;
                rbcs.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();
        }

        public void saveViralLoad(List<ViralLoad> viralList) {
            ViralLoad viral = db.MCDTs.Find(viralList.Single().MCDT_ID) as ViralLoad;
            viral.LabExam_data_in = DateTime.Now;

            foreach(ViralLoad v in viralList) {
                viral.value = v.value;
                viral.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();
        }

        public void saveWbcs(List<WBCS> wbcsList) {
            WBCS wbcs = db.MCDTs.Find(wbcsList.Single().MCDT_ID) as WBCS;
            wbcs.LabExam_data_in = DateTime.Now;

            foreach(WBCS w in wbcsList) {
                wbcs.Basophil = w.Basophil;
                wbcs.Eosinophil = w.Eosinophil;
                wbcs.Monocytes = w.Monocytes;
                wbcs.Neutrophil = w.Neutrophil;
                wbcs.LabExam_date_out = DateTime.Now;
            }

            db.SaveChanges();
        }

        public List<McdtViewModel> ListMcdts() {
            AccessDatabase();
            return listMcdtVM;
        }

        private void AccessDatabase() {
            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                //using(SqlConnection connection = new SqlConnection("Data Source=MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=true")) {
                //using (SqlConnection connection = new SqlConnection("Data Source= WANJIKU\\NEWSQLEXPRESS ; Initial Catalog =HPCareDBContext;Integrated Security=SSPI"))
                //{
                SqlCommand command = new SqlCommand("SELECT MCDTs.MCDT_ID, MCDTs.MCDT_type, MCDTs.MCDT_date, MCDTs.LabExam_data_in, MCDTs.LabExam_date_out, Users.User_id," + 
                    " Users.Name , MCDTs.Discriminator FROM ClinicRegistryManagers INNER JOIN MCDTManagers ON ClinicRegistryManagers.ClinicRegistryManagerId = MCDTManagers.clinicRegistryManager_ClinicRegistryManagerId " + 
                    "INNER JOIN MCDTStaffManagers ON MCDTManagers.MCDTStaffManager_MCDTStaffManager_id = MCDTStaffManagers.MCDTStaffManager_id INNER JOIN MCDTs ON " +
                    "MCDTStaffManagers.mcdt_MCDT_ID = MCDTs.MCDT_ID INNER JOIN Patient ON ClinicRegistryManagers.Clinic_patient_User_id = Patient.User_id INNER JOIN " +
                    "Users ON Patient.User_id = Users.User_id", connection);
                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();

                DbDataReader dbDataReader = command.ExecuteReader();
                McdtViewModel viewModel;

                while(dbDataReader.Read()) {
                    viewModel = new McdtViewModel {
                        McdtId = dbDataReader.GetInt32(0),
                        McdtType = dbDataReader.GetInt32(1),
                        McdtDate = GetDateDefault(dbDataReader, 2),
                        LabDateIn = GetDateDefault(dbDataReader, 3),
                        LabDateOut = GetDateDefault(dbDataReader, 4),
                        UserId = dbDataReader.GetInt32(5),
                        UserName = dbDataReader.GetString(6),
                        Discriminator = dbDataReader.GetString(7)
                    };
                    listMcdtVM.Add(viewModel);
                }
            }
        }

        private DateTime GetDateDefault(DbDataReader reader, int colIndex) {
            return (reader.IsDBNull(colIndex) ? new DateTime(1970, 01, 01) : reader.GetDateTime(colIndex));
        }
    }
}
