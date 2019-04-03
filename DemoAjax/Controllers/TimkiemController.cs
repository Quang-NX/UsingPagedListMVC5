using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAjax.Controllers
{
    public class TimkiemController : Controller
    {
        DbConnectionstring db = new DbConnectionstring();
        // GET: Timkiem
        public ActionResult KQTimKiem(string sTuKhoa)
        {
            //
            var list = db.Employees.Where(n => n.Name.Contains(sTuKhoa));
            
            return View(list.OrderBy(n=>n.Name));
        }
    }
}