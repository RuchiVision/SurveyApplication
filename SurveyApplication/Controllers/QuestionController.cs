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
        //[Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult Index(int id)
        {
            TblQuestion model = _context.TblQuestions.Find(id);
            var data = _context.TblQuestions.Where(x => x.SurveyId == id).Select(x => x.Question).ToList();
            ViewData["data"] = data;
            var datas = _context.TblQuestions.Where(x => x.SurveyId == id).Select(x => x.ControlType).FirstOrDefault();
            ViewBag.datas = datas;
            var options = _context.TblQuestions.Where(x => x.SurveyId == id).Select(x => x.ControlOptions).FirstOrDefault();
            ViewBag.options = options;
            //main
            //var t = _context.TblQuestions.Where(x => x.SurveyId == id).Select(x => new { x.Question, x.ControlType }).ToList();
            //ViewBag.t = t;
            return View();
        }
         [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult QuestionList()
        {
            var data = _context.TblQuestions.ToList();
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create(int id)
        {
            TblSurvey model = _context.TblSurveys.Find(id);
            var data = _context.TblSurveys.Where(x => x.SurveyId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.SurveyName = data;
            ViewBag.SurveyId = id;
            return View();
        }
        [Authorize(Roles = "Admin")]
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
            _context.TblQuestions.Where(x => x.QueId == model.QueId).Select(x => x.SurveyId == model.SurveyId).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(TblQuestion model,int id)
        {
            var data = _context.TblQuestions.Where(x => x.QueId == model.QueId).FirstOrDefault();
            var datas = _context.TblSurveys.Where(x => x.SurveyId == id).Select(x => x.Title).FirstOrDefault();
            ViewBag.SurveyName = datas;
            if (data != null)
            {
                data.Question = model.Question;
                data.ControlOptions = model.ControlOptions;
                data.ControlType = model.ControlType;
                _context.SaveChanges();
            }
           
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