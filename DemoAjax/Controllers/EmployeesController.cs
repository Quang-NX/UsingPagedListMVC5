using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAjax.Controllers
{
    public class EmployeesController : Controller
    {
		DbConnectionstring db = new DbConnectionstring();
        // GET: Employees
		public ActionResult Index()
		{
			return View();
		}
        public JsonResult List()
        {
			var result = db.Employees.ToList();
			return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}