using Calc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebCalc.Models;
using Domain.Managers;
using Domain.Models;


//фильтр по операциям
namespace WebCalc.Controllers
{
    public class CalcController : Controller
    {

        private IHistoryManager Manager { get; set; }

        public CalcController()
        {
            Manager = new HistoryManager();
        }

        // GET: Calc
        public ActionResult Index(CalcModel data)
        {
            var model = data ?? new CalcModel();


            if (ModelState.IsValid)
            {
                var calcHelper = new Helper();
                string operation = model.Operation;

                if (operation != null)
                {
                    var method = calcHelper.GetType().GetMethod(operation);
                    model.Result = Convert.ToDouble(method.Invoke(calcHelper, new object[] { model.X, model.Y }));
                }

                var oper = string.Format("{0} {1} {2} = {3}", model.X, model.Operation, model.Y, model.Result);
                AddOperationToHistory(model.X, model.Operation, model.Y, model.Result);
            }
            ViewData.Model = model;
            return View();
        }

        public ActionResult History()
        {
            return View(GetOperations());
        }

        #region РАБОТА С БД
        private void AddOperationToHistory(int x, string operation, int y, double result)
        {
            var history = new Domain.Models.History();

            history.CreationDate = DateTime.Now;
            history.X = x;
            history.Operation = operation;
            history.Y = y;
            history.Result = result;

                Manager.Add(history);
            
        }

        private IEnumerable<History> GetOperations()
        {
            return Manager.List();
            //var connectionString = ConfigurationManager.ConnectionStrings["ElmaCon"].ConnectionString;
            //var result = new List<string>();
            ////соединиться с базой
            //using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    var queryString = "SELECT [X], [Operation], [Y], [Result] FROM [dbo].[History]";

            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();

            //    var reader = command.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            result.Add(reader.GetValue(0).ToString() + " " + reader.GetValue(1).ToString() + " " + reader.GetValue(2).ToString() + " " + reader.GetValue(3).ToString());
            //        }
            //    }
            //    reader.Close();
            //}
            //return result;
        }
        #endregion
    }
}