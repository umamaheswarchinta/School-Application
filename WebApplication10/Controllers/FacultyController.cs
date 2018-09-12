using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication10.Models;
using WebApplication10.Controllers;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Script.Serialization;
using System.Threading;
using System.Web.ModelBinding;

namespace WebApplication10.Controllers
{
    public class FacultyController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Faculty s)
        {
          
                if (ModelState.IsValid)
                {
                    int i = objdalfacultyservices.AddFaculty(s);
                    if (i == 1)
                    {
                    return RedirectToAction("List");
                }

               
                }
                else
                {
                    return Json(ModelState.Values, JsonRequestBehavior.AllowGet);
                }
           
            return RedirectToAction("List");
        }
        /*[HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Models.Faculty objfacultyservicesmodel)
        {
            int i = objdalfacultyservices.AddFaculty(objfacultyservicesmodel);
            if (i == 1)
            {
                Response.Write("Record added");
            }
            else
            {
                Response.Write("Failed");
            }
            return View();
        }

        [HttpPost]
        public string AddFaculty(Models.Faculty objfacultyservicesmodel)
        {
            int i = objdalfacultyservices.AddFaculty(objfacultyservicesmodel);
            if (i == 1)
            {
                Response.Write("Record added");
            }
            else
            {
                Response.Write("Failed");
            }
            return "record submitted";
        }*/
        [HttpGet]
        public ActionResult Delete(int id)
        {
            int i = objdalfacultyservices.DeleteFaculty(id);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Models.Faculty s = objdalfacultyservices.Search(id);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(Models.Faculty f1)
        {
            int i = objdalfacultyservices.UpdateFaculty(f1);
            if (i == 1)
                Response.Write("Record Updated");
            return RedirectToAction("List");
        }
        DAL.FacultyService objdalfacultyservices = new DAL.FacultyService();
        [HttpGet]
        public ActionResult List(string s)
        {
            if (s == null)
            {
                List<Faculty> l = objdalfacultyservices.List();
                return View(l);
            }
            else
            {
                
                List<Faculty> l = objdalfacultyservices.Search1(s);
                return Json(l, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Models.Faculty l = objdalfacultyservices.GetDetails(id);
            return View(l);
        }
    }
}