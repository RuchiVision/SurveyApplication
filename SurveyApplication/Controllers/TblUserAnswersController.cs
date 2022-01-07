using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyApplication;
namespace SurveyApplication.Controllers
{
    public class TblUserAnswersController : Controller
    {
        private ProductDBEntities db = new ProductDBEntities();
        public ActionResult Index()
        {
            var tblUserAnswers = db.TblUserAnswers.Include(t => t.TblQuestion).Include(t => t.TblUser);
            return View(tblUserAnswers.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.QuesId = new SelectList(db.TblQuestions, "QueId", "Question");
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "FirstName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TblUserAnswer tblUserAnswer)
        {
            if (ModelState.IsValid)
            {
                db.TblUserAnswers.Add(tblUserAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuesId = new SelectList(db.TblQuestions, "QueId", "Question", tblUserAnswer.QuesId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "FirstName", tblUserAnswer.UserId);
            return View(tblUserAnswer);
        }
        public ActionResult Edit(int? id)
        {
            TblUserAnswer tblUserAnswer = db.TblUserAnswers.Find(id);
            ViewBag.QuesId = new SelectList(db.TblQuestions, "QueId", "Question", tblUserAnswer.QuesId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "FirstName", tblUserAnswer.UserId);
            return View(tblUserAnswer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TblUserAnswer tblUserAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUserAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuesId = new SelectList(db.TblQuestions, "QueId", "Question", tblUserAnswer.QuesId);
            ViewBag.UserId = new SelectList(db.TblUsers, "UserId", "FirstName", tblUserAnswer.UserId);
            return View(tblUserAnswer);
        }
        public ActionResult Delete(int? id)
        {
            var data = db.TblUserAnswers.SingleOrDefault(x => x.AnswerId == id);
            db.TblUserAnswers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
