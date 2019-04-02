using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeusSystem.Models;

namespace ZeusSystem.Controllers
{
    [Authorize]
    public class EmplyeeInfoesController : Controller
    {
        IMockEmployees db;
        //private ZeusDB db = new ZeusDB();
        public EmplyeeInfoesController()
        {
            this.db = new IDataEmployees();
        }

        public EmplyeeInfoesController(IMockEmployees mockDb)
        {
            this.db = mockDb;
        }
        [AllowAnonymous]
        // GET: EmplyeeInfoes
        public ActionResult Index()
        {
            return View("Index", db.EmplyeeInfos.OrderBy(e => e.EmployeeName).ToList());
        }

        // GET: EmplyeeInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.Find(id);
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.SingleOrDefault(e => e.EmployeeID == id);
            if (emplyeeInfo == null)
            {
                return HttpNotFound();
            }
            return View("Details",emplyeeInfo);
        }

        // GET: EmplyeeInfoes/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: EmplyeeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeName,EmployeeAddress,EmployeePhoneNumber,EmployeeEmailID,EmployeeDoB")] EmplyeeInfo emplyeeInfo)
        {
            if (ModelState.IsValid)
            {
                //db.EmplyeeInfos.Add(emplyeeInfo);
                //db.SaveChanges();
                db.Save(emplyeeInfo);
                return RedirectToAction("Index");
            }

            return View("Create",emplyeeInfo);
        }

        // GET: EmplyeeInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.Find(id);
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.SingleOrDefault(e => e.EmployeeID == id);
            if (emplyeeInfo == null)
            {
                return HttpNotFound();
            }
            return View("Edit",emplyeeInfo);
        }

        // POST: EmplyeeInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeName,EmployeeAddress,EmployeePhoneNumber,EmployeeEmailID,EmployeeDoB")] EmplyeeInfo emplyeeInfo)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(emplyeeInfo).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(emplyeeInfo);

                return RedirectToAction("Index");
            }
            return View("Edit",emplyeeInfo);
        }

        // GET: EmplyeeInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.Find(id);
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.SingleOrDefault(e => e.EmployeeID == id);
            if (emplyeeInfo == null)
            {
                return HttpNotFound();
            }
            return View("Delete",emplyeeInfo);
        }

        // POST: EmplyeeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.Find(id);
            EmplyeeInfo emplyeeInfo = db.EmplyeeInfos.SingleOrDefault(e => e.EmployeeID == id);
            //db.EmplyeeInfos.Remove(emplyeeInfo);
            //db.SaveChanges();
            db.Delete(emplyeeInfo);
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
    }
}
