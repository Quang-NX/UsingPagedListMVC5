using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAjax.Controllers
{
    public class DemoAjaxController : Controller
    {
        // GET: DemoAjax
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAjax()
        {
            return Content("Hello Ajax");
        }
        //cach 2
        public ActionResult LoadAjaxBGF(FormCollection f)
        {
            string KQ = f["text1"].ToString();
            return Content(KQ);
        }
    }
}