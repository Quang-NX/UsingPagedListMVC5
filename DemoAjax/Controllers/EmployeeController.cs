using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoAjax.Models;
using Domain;
using PagedList;

namespace DemoAjax.Controllers
{
    public class EmployeeController : Controller
    {
        private DbConnectionstring db = new DbConnectionstring();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        //get autocomplete
        [HttpPost]
        public JsonResult AutoCompleteCity(string Prefix)
        {
            ////Searching records from list using LINQ query  
            //var CityName = (from N in ObjList
            //                where N.Name.StartsWith(Prefix)
            //                select new { N.Name });
            var CityName = db.Employees.Where(em => em.Name.StartsWith(Prefix)).Select(em => new { Name = em.Name });
            return Json(CityName, JsonRequestBehavior.AllowGet);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Age,Slary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Age,Slary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpGet]
        public JsonResult Search(string keyword)
        {
            var data = db.Employees.Where(em => em.Name.Contains(keyword)).Select(se => se.Name).ToList();
            return Json(new { data = data, status = true }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetPaging(int? page)
        {
            var listEmployee = db.Employees.ToList();
            int pageSize = 2;
            //toán tử tương đương với nếu page!=null thì pageNumber =1 ngược lại =page
            int pageNumber = (page ?? 1);
            return PartialView("_PartialViewEmployee", listEmployee.ToPagedList(pageNumber, pageSize));
        }
    }
}
