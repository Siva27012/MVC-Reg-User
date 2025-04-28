using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Reg_User.Models;

namespace MVC_Reg_User.Controllers
{
    public class NewRegController : Controller
    {
        // GET: NewReg
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserClass uc, HttpPostedFileBase file)
        {
            string maincon = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(maincon);
            string sqlquery = "insert into [dbo].[MVCregUser] (Uname,Uemail,Upwd,Gender,Uimg) values (@Uname,@Uemail,@Upwd,@Gender,@Uimg)";
            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            cmd.Parameters.AddWithValue("@Uname", uc.Uname);
            cmd.Parameters.AddWithValue("@Uemail", uc.Uemail);
            cmd.Parameters.AddWithValue("@Upwd", uc.Upwd);
            cmd.Parameters.AddWithValue("@Gender", uc.Gender);
            string imagePath = null;

            if (file != null) 
            {
                string filename = Path.GetFileName(file.FileName);
                imagePath = "/User-Images/" + filename;
                string fullPath = Server.MapPath(imagePath);

                // Ensure the directory exists
                string dir = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                file.SaveAs(fullPath);
            }
            cmd.Parameters.AddWithValue("@Uimg","~/User-Images/"+file.FileName );
            cmd.ExecuteNonQuery();
            sqlconn.Close();
            ViewData["Message"] = "User Record " + uc.Uname + " Is Saved Successfully !";
            return View();
        }
    }
}