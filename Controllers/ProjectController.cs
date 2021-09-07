using practice2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practice2.Controllers
{
    public class ProjectController : Controller
    {

        //public ActionResult AddEdit()
        //{
        //    var projectVM = new PracticeViewModel();
        //    //passing a viewmodle here
        //    return View(projectVM);
        //}

        //[HttpPost]
        //public ActionResult AddEdit(PracticeViewModel prjVM)
        //{
        //    PracticeViewModel vm;
        //    vm = new PracticeViewModel();
        //    return View(vm);

        //}
        // GET: Project


        public ActionResult Index()
        {
            return View("DataList");

        }

        //Add Edit project 
        public ActionResult AddEdit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = "-1";
            }
            ViewData["ProjectId"] = id;
            return View();
        }


    }
}