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
            return Json(impLabExams.ListMcdts(), JsonRequestBehavior.AllowGet);
        }

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






        ////// *** Apagar daqui **** ///
        //////[HttpGet]
        ////public JsonResult MonitorizationGraphsDatesJson(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
        ////    List<DateTime> dates = ReturnRowsDateTime(mcdtType, startDate, endDate);

        ////    return Json(dates, JsonRequestBehavior.AllowGet);
        ////}

        ////public List<DateTime> ReturnRowsDateTime(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
        ////    using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
        ////        //using(SqlConnection connection = new SqlConnection("Data Source=MÁRCIA\\SQLSERVER; Initial Catalog =HPCareDBContext; Integrated Security=true")) {
        ////        //SELECT      kft.* 
        ////        //FROM Users INNER JOIN
        ////        //         Users AS Users_1 ON Users.User_id = Users_1.User_id CROSS JOIN
        ////        //         ClinicRegistryManagers INNER JOIN
        ////        //         MCDTManagers ON ClinicRegistryManagers.ClinicRegistryManagerId = MCDTManagers.clinicRegistryManager_ClinicRegistryManagerId INNER JOIN
        ////        //         MCDTStaffManagers ON MCDTManagers.MCDTStaffManager_MCDTStaffManager_id = MCDTStaffManagers.MCDTStaffManager_id INNER JOIN
        ////        //         MCDTs ON MCDTStaffManagers.mcdt_MCDT_ID = MCDTs.MCDT_ID inner join KFT on kft.MCDT_ID = mcdts.MCDT_ID and users.User_id = 4;
        ////        SqlCommand command = new SqlCommand("select mcdt_date, " + mcdtType + ".* from mcdts, " + mcdtType + " where mcdts.mcdt_id = " + mcdtType + ".mcdt_id and MCDT_date > '" + (startDate.Year + "/" + startDate.Month + "/" + startDate.Day) + "' and mcdt_Date < '" + (endDate.Year + "/" + endDate.Month + "/" + endDate.Day) + "';", connection);

        ////        command.CommandType = CommandType.Text;
        ////        command.Connection = connection;
        ////        connection.Open();
        ////        DbDataReader dbDataReader = command.ExecuteReader();
        ////        var columns = new List<DateTime>();
        ////        while(dbDataReader.Read()) {
        ////            columns.Add(dbDataReader.GetDateTime(0));
        ////        }
        ////        dbDataReader.Close();
        ////        return columns;
        ////    }
        ////}

        ////// **** até aqui ******* //


        //// **** apagar daqui *******//

        ////[HttpGet]
        //public JsonResult MonitorizationGraphsValuesJson(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
        //    List<object> values = ReturnRowsValues(mcdtType, startDate, endDate);

        //    return Json(values, JsonRequestBehavior.AllowGet);
        //}

        ///// <summary>
        ///// metodo que devolve apenas as colunas que sao referentes ao type e id que é passado como parametro - VALUES
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public List<object> ReturnRowsValues(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
        //    using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
        //        SqlCommand command = new SqlCommand("select mcdt_date, " + mcdtType + ".* from mcdts, " + mcdtType + " where mcdts.mcdt_id = " + mcdtType + ".mcdt_id and MCDT_date > '" + (startDate.Year + "/" + startDate.Month + "/" + startDate.Day) + "' and mcdt_Date < '" + (endDate.Year + "/" + endDate.Month + "/" + endDate.Day) + "';", connection);

        //        command.CommandType = CommandType.Text;
        //        command.Connection = connection;
        //        connection.Open();
        //        DbDataReader dbDataReader = command.ExecuteReader();
        //        var columns = new List<object>();
        //        var counter = 0;
        //        while(dbDataReader.Read()) {
        //            for(int i = 2; i < dbDataReader.FieldCount; i++) {
        //                columns.Add(dbDataReader.GetDouble(i));
        //            }
        //            counter++;
        //        }
        //        columns.Add(counter);
        //        dbDataReader.Close();
        //        return columns;
        //    }
        //}

        //// **** até aqui ******* //


        //// **** apagar daqui *******//

        ////[HttpGet]
        //public JsonResult MonitorizationGraphsColumnsNamesJson(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
        //    List<string> columns = ReturnColumnsNames(mcdtType, startDate, endDate);
        //    return Json(columns, JsonRequestBehavior.AllowGet);
        //}

        ///// <summary>
        ///// metodo que devolve as COLUMNS NAMES
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public List<string> ReturnColumnsNames(MCDTType mcdtType, DateTime startDate, DateTime endDate) {
        //    using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
        //        SqlCommand command = new SqlCommand("select mcdt_date, " + mcdtType + ".* from mcdts, " + mcdtType + " where mcdts.mcdt_id = " + mcdtType + ".mcdt_id and MCDT_date > '" + (startDate.Year + "/" + startDate.Month + "/" + startDate.Day) + "' and mcdt_Date < '" + (endDate.Year + "/" + endDate.Month + "/" + endDate.Day) + "';", connection);

        //        command.CommandType = CommandType.Text;
        //        command.Connection = connection;
        //        connection.Open();
        //        DbDataReader dbDataReader = command.ExecuteReader();
        //        var columns = new List<string>();
        //        for(int i = 2; i < dbDataReader.FieldCount; i++) {
        //            columns.Add(dbDataReader.GetName(i));
        //        }
        //        dbDataReader.Close();
        //        return columns;
        //    }
        //}

        //// ******** até aqui *******//







        public ActionResult SpecificGraphMonitorization() {
            return PartialView();
        }

        public JsonResult SpecificMonitorizationJson(string discriminator, string specificParameter, string listaIds) {
            List<double> valuesList = SpecificValues(discriminator, specificParameter, listaIds);
            return Json(valuesList, JsonRequestBehavior.AllowGet);
        }

        public List<double> SpecificValues(string discriminator, string specificParameter, string listaIds) {
            if(specificParameter.Equals("null")) {
                specificParameter = TesteColumnNames(discriminator).First();
            }
            
            var split = listaIds.Split(',');
            var result = split;
            List<int> mcdtsIdsList = new List<int>();

            for(int j = 0; j < result.Length - 1; j++) {
                mcdtsIdsList.Add(Convert.ToInt32(result[j]));
            }

            List<double> values = new List<double>();
            foreach(var item in mcdtsIdsList) {

                using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                    SqlCommand command = new SqlCommand("select " + specificParameter + " from " + discriminator + " where " + TesteColumnNames(discriminator).First() + " != '' and mcdt_id = " + item + ";", connection);

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    DbDataReader dbDataReader = command.ExecuteReader();
                    
                    while(dbDataReader.Read()) {
                        for(int i = 0; i < dbDataReader.FieldCount; i++) {
                            values.Add(dbDataReader.GetDouble(i));
                        }
                    }
                    dbDataReader.Close();
                    
                }
            }
            return values;
        }

        public JsonResult PatientZero() {
            List<double> list = new List<double>();
            list.Add(25);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // *************************************************************** //

        /// <summary>
        /// devolve as datas dos mcdt's que sao passadas na lista 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult TesteDateJson(string listIds) {
            var split = listIds.Split(',');
            var result = split;
            List<int> mcdtsIdsList = new List<int>();

            for(int j = 0; j < result.Length - 1; j++) {
                mcdtsIdsList.Add(Convert.ToInt32(result[j]));
            }

            List<DateTime> dates = new List<DateTime>();
            MCDT mcdt;

            foreach(var item in mcdtsIdsList) {
                mcdt = db.MCDTs.Find(item);
                dates.Add((DateTime)mcdt.MCDT_date);
            }
            return Json(dates, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// metodo auxiliar que vai buscar o nome das colunas de cada mcdt. (Exemplo: KFT -> bun, creatinine, uricAcid)
        /// </summary>
        /// <returns></returns>
        private List<string> TesteColumnNames(string discriminator) {
            List<string> columns = new List<string>();

            using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {
                SqlCommand command = new SqlCommand("select " + discriminator + ".* from " + discriminator + ";", connection);

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                connection.Open();
                DbDataReader dbDataReader = command.ExecuteReader();

                for(int i = 1; i < dbDataReader.FieldCount; i++) { //comeca na posicao 1 para que o MCDT_ID nao seja adicionado à lista de column names
                    columns.Add(dbDataReader.GetName(i));
                }
                dbDataReader.Close();
            }

            return columns;
        }

        [HttpGet]
        public JsonResult TesteColumnsNamesJson(string discrimininator) {
            List<string> columnsNames = TesteColumnNames(discrimininator);
            return Json(columnsNames, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// metodo que devolve os valores de cada row dos mcdts que são passados na lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult TesteValores(string mcdtsIds, string discriminator) {
            var split = mcdtsIds.Split(',');
            var result = split;
            List<int> mcdtsIdsList = new List<int>();

            for(int j = 0; j < result.Length - 1; j++) {
                mcdtsIdsList.Add(Convert.ToInt32(result[j]));
            }

            List<double> valoresMcdts = new List<double>();
            List<string> nomeColunas = TesteColumnNames(discriminator);
            var counter = 0;// var auxiliar que conta o nome de rows que existem 

            foreach(var item in mcdtsIdsList) {
                using(SqlConnection connection = new SqlConnection("Data Source=SQL5025.myASP.NET;Initial Catalog=DB_A0ADFA_HPCareDBContext;User Id=DB_A0ADFA_HPCareDBContext_admin;Password=hpcare2016;")) {

                    SqlCommand command = new SqlCommand("select " + discriminator + ".* from " + discriminator + ", mcdts where mcdts.mcdt_id = " + discriminator + ".mcdt_id and " + nomeColunas.First() + " != '' and mcdts.mcdt_id = " + item + ";", connection);

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    connection.Open();
                    DbDataReader dbDataReader = command.ExecuteReader();

                    while(dbDataReader.Read()) {
                        for(int i = 1; i < dbDataReader.FieldCount; i++) {// comeca no 1 para que o id nao seja introduzido na lista de valores
                            valoresMcdts.Add(dbDataReader.GetDouble(i));
                        }
                        counter++;
                    }
                    dbDataReader.Close();
                }
            }
            valoresMcdts.Add(counter);

            return Json(valoresMcdts, JsonRequestBehavior.AllowGet);
        }

    }
}

