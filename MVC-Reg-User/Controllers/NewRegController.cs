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
            string maincon = ConfigurationManager.ConnectionStrings["Myconnec tion"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(maincon);
            string sqlquery = "insert into [dbo].[MVCregUser] (Uname,Uemail,Upwd,Gender,Uimg) values (@Unmae,@email,@Upwd,@Gender,@Uimg)";
            SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            cmd.Parameters.AddWithValue("@Uname", uc.Uname);
            cmd.Parameters.AddWithValue("@Uemail", uc.Uemail);
            cmd.Parameters.AddWithValue("@Upwd", uc.Upwd);
            cmd.Parameters.AddWithValue("@Gender", uc.Gender);
            if (file != null) 
            {
                string filename = Path.GetFileName(file.FileName);
                string imagePath = Path.Combine(Server.MapPath("~/User-Images/"), filename);
                file.SaveAs(imagePath);
            }
            cmd.Parameters.AddWithValue("@Uimg","~/User-Images/"+file.FileName );
            return View();
        }
    }
}