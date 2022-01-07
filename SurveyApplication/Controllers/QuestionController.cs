using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SurveyApplication.Controllers
{
    public class QuestionController : Controller
    {
        ProductDBEntities _context = new ProductDBEntities();
        public ActionResult Index()
        {
            var data = _context.TblQuestions.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            TblSurvey model = _context.TblSurveys.Find(id);
            var data = _context.TblSurveys.Where(x => x.SurveyId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.Employeedetails = data;
            ViewBag.SurveyId = id;
            return View();
        }
        [HttpPost]
        public ActionResult InsertData(int id, string name,string td, string optioons)
        {
            TblQuestion model = new TblQuestion();
            model.Question = td;
            model.SurveyId = id;
            model.ControlType = name;
            model.ControlOptions = optioons;
            _context.TblQuestions.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TblQuestion model = _context.TblQuestions.Find(id);
            _context.TblQuestions.Where(x => x.QueId == id).FirstOrDefault();
            TblSurvey models = _context.TblSurveys.Find(id);
            var data = _context.TblSurveys.Where(x => x.SurveyId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.Employeedetails = data;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(TblQuestion model,int id)
        {
            var data = _context.TblQuestions.Where(x => x.QueId == model.QueId).FirstOrDefault();
            if(data != null)
            {
                data.SurveyId = model.SurveyId;
                data.Question = model.Question;
                data.ControlOptions = model.ControlOptions;
                data.ControlType = model.ControlType;
                _context.SaveChanges();
            }
            ViewBag.Survey = new SelectList(_context.TblSurveys, "SurveyId", "Title", model.SurveyId);
            return RedirectToAction("Index",model);
        }
        public ActionResult Delete(int id)
        {
            var data = _context.TblQuestions.SingleOrDefault(x => x.QueId == id);
            _context.TblQuestions.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}