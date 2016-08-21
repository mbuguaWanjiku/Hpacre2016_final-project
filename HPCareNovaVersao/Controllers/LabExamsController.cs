using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Entities.MCDT;
using DataLayer.EntityFramework;
using DataLayer.Entities;
using DataLayer.Entities.MCDTEntities;
using System.Data.SqlClient;
using System.Data.Common;
using BusinessLayer.Implementation;

namespace PresentationLayer.Controllers {
    public class LabExamsController : Controller {
        private HPCareDBContext db = new HPCareDBContext();
        private impLabExams impLabExams;

        public LabExamsController() {
            impLabExams = new impLabExams(db);
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // lab exams com angular //

        public ActionResult ListMcdts() {
            return PartialView();
        }

        public JsonResult ListPatientLabExamsJson() {
            var labExamsQuery = from mcdt in db.MCDTs
                                from staff in db.MCDTStaffManagers
                                from manager in db.MCDTManagers
                                from clinic in db.ClinicRegistryManagers
                                from lab in db.LabExams
                                from users in db.Users
                                where mcdt.MCDT_ID == staff.mcdt.MCDT_ID
                                && manager.MCDTStaffManager.MCDTStaffManager_id == staff.MCDTStaffManager_id
                                && clinic.ClinicRegistryManagerId == manager.clinicRegistryManager.ClinicRegistryManagerId
                                && clinic.Clinic_patient.User_id == users.User_id
                                && mcdt.MCDT_ID == lab.MCDT_ID
                                //&& lab.LabExam_data_in == null
                                //&& lab.LabExam_date_out == null
                                select new {
                                    mcdt.MCDT_ID,
                                    users.Name,
                                    users.User_id,
                                    mcdt.MCDT_type,
                                    McdtDate = mcdt.MCDT_date.Value.Day + "/" + mcdt.MCDT_date.Value.Month + "/" + mcdt.MCDT_date.Value.Year,
                                    LabDateIn = lab.LabExam_data_in.Value.Day + "/" + lab.LabExam_data_in.Value.Month + "/" + lab.LabExam_data_in.Value.Year,
                                    LabDateOut = lab.LabExam_date_out.Value.Day + "/" + lab.LabExam_date_out.Value.Month + "/" + lab.LabExam_date_out.Value.Year,
                                };

            return Json(labExamsQuery, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult PatientLabExamsJson(int id) {
        //    var labExamsQuery = from mcdt in db.MCDTs
        //                        from staff in db.MCDTStaffManagers
        //                        from manager in db.MCDTManagers
        //                        from clinic in db.ClinicRegistryManagers
        //                        from lab in db.LabExams
        //                        from users in db.Users
        //                        where mcdt.MCDT_ID == staff.mcdt.MCDT_ID
        //                        && manager.MCDTStaffManager.MCDTStaffManager_id == staff.MCDTStaffManager_id
        //                        && clinic.ClinicRegistryManagerId == manager.clinicRegistryManager.ClinicRegistryManagerId
        //                        && mcdt.MCDT_ID == lab.MCDT_ID
        //                        && users.User_id == clinic.Clinic_patient.User_id
        //                        && users.User_id == id
        //                        select new {
        //                            mcdt.MCDT_ID,
        //                            mcdt.MCDT_type,
        //                            McdtDate = mcdt.MCDT_date.Value.Day + "/" + mcdt.MCDT_date.Value.Month + "/" + mcdt.MCDT_date.Value.Year,
        //                            LabDateIn = lab.LabExam_data_in.Value.Day + "/" + lab.LabExam_data_in.Value.Month + "/" + lab.LabExam_data_in.Value.Year,
        //                            LabDateOut = lab.LabExam_date_out.Value.Day + "/" + lab.LabExam_date_out.Value.Month + "/" + lab.LabExam_date_out.Value.Year,
        //                            users.Name,
        //                        };

        //    return Json(labExamsQuery, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetKFt(int id) {
        //    var list = from m in db.MCDTs
        //               from k in db.MCDTs.OfType<KFT>()
        //               where m.MCDT_ID == k.MCDT_ID &&
        //               m.MCDT_ID == id
        //               select new {
        //                   m.MCDT_ID,
        //                   McdtDate = m.MCDT_date.Value.Day + "/" + m.MCDT_date.Value.Month + "/" + m.MCDT_date.Value.Year,
        //                   k.BUN,
        //                   k.Creatinine,
        //                   k.uricAcid
        //               };

        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public void saveKftResults(List<KFT> kftList) {
            impLabExams.saveKft(kftList);
        }

        [HttpPost]
        public void saveLftResults(List<LFT> lftList) {
            impLabExams.saveLft(lftList);
        }

        [HttpPost]
        public void saveLymphocyteResults(List<LymphocytesSubsets> lymphocytesList) {
            impLabExams.saveLymphocyteSubsets(lymphocytesList);
        }

        [HttpPost]
        public void savePlateletsResults(List<PlateletsCount> plateletsList) {
            impLabExams.savePlateletsCount(plateletsList);
        }

        [HttpPost]
        public void saveRbcIndicesResults(List<RBCIndices> rbcIndicesList) {
            impLabExams.saveRbcIndices(rbcIndicesList);
        }

        [HttpPost]
        public void saveRbcsResults(List<RBCS> rbcsList) {
            impLabExams.saveRbcs(rbcsList);
        }

        [HttpPost]
        public void savViralLoadResults(List<ViralLoad> viralLoadList) {
            impLabExams.saveViralLoad(viralLoadList);
        }

        [HttpPost]
        public void saveWbcsResults(List<WBCS> wbcsList) {
            impLabExams.saveWbcs(wbcsList);
        }

        public ActionResult MonitorizationGraphs() {
            return PartialView();
        }

        //[HttpGet]
        public JsonResult MonitorizationGraphsDatesJson(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
            List<DateTime> dates = ReturnRowsDateTime(mcdtType, startDate, endDate);

            return Json(dates, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// metodo que devolve apenas as colunas que sao referentes ao type e id que é passado como parametro - DATETIME
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<DateTime> ReturnRowsDateTime(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
            //using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
            using(SqlConnection connection = new SqlConnection("Data Source=MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=true")) {
                //SELECT      kft.* 
                //FROM Users INNER JOIN
                //         Users AS Users_1 ON Users.User_id = Users_1.User_id CROSS JOIN
                //         ClinicRegistryManagers INNER JOIN
                //         MCDTManagers ON ClinicRegistryManagers.ClinicRegistryManagerId = MCDTManagers.clinicRegistryManager_ClinicRegistryManagerId INNER JOIN
                //         MCDTStaffManagers ON MCDTManagers.MCDTStaffManager_MCDTStaffManager_id = MCDTStaffManagers.MCDTStaffManager_id INNER JOIN
                //         MCDTs ON MCDTStaffManagers.mcdt_MCDT_ID = MCDTs.MCDT_ID inner join KFT on kft.MCDT_ID = mcdts.MCDT_ID and users.User_id = 4;
                SqlCommand command = new SqlCommand("select mcdt_date, " + mcdtType + ".* from mcdts, " + mcdtType + " where mcdts.mcdt_id = " + mcdtType + ".mcdt_id and MCDT_date > '" + (startDate.Year + "/" + startDate.Month + "/" + startDate.Day) + "' and mcdt_Date < '" + (endDate.Year + "/" + endDate.Month + "/" + endDate.Day) + "';", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                var columns = new List<DateTime>();
                while(dbDataReader.Read()) {
                    columns.Add(dbDataReader.GetDateTime(0));
                }
                dbDataReader.Close();
                return columns;
            }
        }

        //[HttpGet]
        public JsonResult MonitorizationGraphsValuesJson(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
            List<object> values = ReturnRowsValues(mcdtType, startDate, endDate);

            return Json(values, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// metodo que devolve apenas as colunas que sao referentes ao type e id que é passado como parametro - VALUES
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<object> ReturnRowsValues(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
            //using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
            using(SqlConnection connection = new SqlConnection("Data Source=MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=true")) {
                //SELECT      kft.* 
                //FROM Users INNER JOIN
                //         Users AS Users_1 ON Users.User_id = Users_1.User_id CROSS JOIN
                //         ClinicRegistryManagers INNER JOIN
                //         MCDTManagers ON ClinicRegistryManagers.ClinicRegistryManagerId = MCDTManagers.clinicRegistryManager_ClinicRegistryManagerId INNER JOIN
                //         MCDTStaffManagers ON MCDTManagers.MCDTStaffManager_MCDTStaffManager_id = MCDTStaffManagers.MCDTStaffManager_id INNER JOIN
                //         MCDTs ON MCDTStaffManagers.mcdt_MCDT_ID = MCDTs.MCDT_ID inner join KFT on kft.MCDT_ID = mcdts.MCDT_ID and users.User_id = 4;
                SqlCommand command = new SqlCommand("select mcdt_date, " + mcdtType + ".* from mcdts, " + mcdtType + " where mcdts.mcdt_id = " + mcdtType + ".mcdt_id and MCDT_date > '" + (startDate.Year + "/" + startDate.Month + "/" + startDate.Day) + "' and mcdt_Date < '" + (endDate.Year + "/" + endDate.Month + "/" + endDate.Day) + "';", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                var columns = new List<object>();
                var counter = 0;
                while(dbDataReader.Read()) {
                    for(int i = 2; i < dbDataReader.FieldCount; i++) {
                        columns.Add(dbDataReader.GetDouble(i));
                    }
                    counter++;
                }
                columns.Add(counter);
                dbDataReader.Close();
                return columns;
            }
        }


        //[HttpGet]
        public JsonResult MonitorizationGraphsColumnsNamesJson(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
            List<string> columns = ReturnColumnsNames(mcdtType, startDate, endDate);
            return Json(columns, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// metodo que devolve apenas as colunas que sao referentes ao type e id que é passado como parametro - COLUMNS NAMES
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> ReturnColumnsNames(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
            //using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
            using(SqlConnection connection = new SqlConnection("Data Source=MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=true")) {
                //SELECT      kft.* 
                //FROM Users INNER JOIN
                //         Users AS Users_1 ON Users.User_id = Users_1.User_id CROSS JOIN
                //         ClinicRegistryManagers INNER JOIN
                //         MCDTManagers ON ClinicRegistryManagers.ClinicRegistryManagerId = MCDTManagers.clinicRegistryManager_ClinicRegistryManagerId INNER JOIN
                //         MCDTStaffManagers ON MCDTManagers.MCDTStaffManager_MCDTStaffManager_id = MCDTStaffManagers.MCDTStaffManager_id INNER JOIN
                //         MCDTs ON MCDTStaffManagers.mcdt_MCDT_ID = MCDTs.MCDT_ID inner join KFT on kft.MCDT_ID = mcdts.MCDT_ID and users.User_id = 4;
                SqlCommand command = new SqlCommand("select mcdt_date, " + mcdtType + ".* from mcdts, " + mcdtType + " where mcdts.mcdt_id = " + mcdtType + ".mcdt_id and MCDT_date > '" + (startDate.Year + "/" + startDate.Month + "/" + startDate.Day) + "' and mcdt_Date < '" + (endDate.Year + "/" + endDate.Month + "/" + endDate.Day) + "';", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                var columns = new List<string>();
                for(int i = 2; i < dbDataReader.FieldCount; i++) {
                    columns.Add(dbDataReader.GetName(i));
                }
                dbDataReader.Close();
                return columns;
            }
        }

        public ActionResult SpecificGraphMonitorization() {
            return PartialView();
        }

        public JsonResult SpecificMonitorizationJson(MCDTType mcdtType, string specificParameter) {
            List<double> valuesList = SpecificValues(mcdtType, specificParameter);
            return Json(valuesList, JsonRequestBehavior.AllowGet);
        }

        public List<double> SpecificValues(MCDTType mcdtType, string specificParameter) {
            //using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
            using(SqlConnection connection = new SqlConnection("Data Source=MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=true")) {
                SqlCommand command = new SqlCommand("select " + specificParameter + " from " + mcdtType + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();
                var values = new List<double>();
                while(dbDataReader.Read()) {
                    for(int i = 0; i < dbDataReader.FieldCount; i++) {
                        values.Add(dbDataReader.GetDouble(i));
                    }
                }
                dbDataReader.Close();
                return values;
            }
        }

        public JsonResult PatientZero() {
            List<double> list = new List<double>();
            list.Add(25);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}

