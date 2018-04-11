using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartialProject.Models;
using System.Data.SqlClient;
using System.Data;

namespace PartialProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddData(FormCollection formData)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=PCI186\SQL2014;Initial Catalog=ankitTemp;Integrated Security=True");

            List<Customer> cm = new List<Customer>();
            Customer c = new Customer();
            c.CustID = Convert.ToInt32(formData["Id"]);
            c.Name = formData["Name"].ToString();
            cm.Add(c);

            string sql = "INSERT INTO Customer (CustomerCode,CustomerName) values (@CustomerCode,@CustomerName)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@CustomerCode", SqlDbType.VarChar);
            cmd.Parameters["@CustomerCode"].Value = c.CustID;

            cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar);
            cmd.Parameters["@CustomerName"].Value = c.Name;
            cmd.ExecuteNonQuery();

            return View();

        }
    }
}