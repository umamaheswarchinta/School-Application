using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;
using WebApplication10.Controllers;
using MySql.Data.MySqlClient;
using System.Data;

namespace WebApplication10.Controllers
{
    public class StudentController : Controller
    {
        DAL.Student objdalstudent = new DAL.Student();
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Student objstudentservicesmodel)
        {
            int i = objdalstudentservices.AddStudent(objstudentservicesmodel);
            if (i == 1)
            {
                Response.Write("Record added");
            }
            else
            {
                Response.Write("Failed");
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public string AddStudent(Models.Student objstudentservicesmodel)
        {
            int i = objdalstudentservices.AddStudent(objstudentservicesmodel);
            if (i == 1)
            {
                Response.Write("Record added");
            }
            else
            {
                Response.Write("Failed");
            }
            return "record submitted";
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            int i = objdalstudentservices.DeleteStudent(id);
            return RedirectToAction("List");
        }
       
        
       [HttpGet]
       public ActionResult Edit(int id)
        {
            Models.Student s = objdalstudentservices.Search(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Models.Student s1)
        {
            int i = objdalstudentservices.UpdateStudent(s1);
            if (i == 1)
                Response.Write("Record Updated");
            return RedirectToAction("List");
        }
        DAL.StudentService objdalstudentservices = new DAL.StudentService();
        
        [HttpGet]
        public ActionResult List()
        {
            List<Student> l = objdalstudentservices.GetStudentList();
            return View(l);
        }
        
    }
}