using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyApplication;
namespace SurveyApplication.Controllers
{
    public class SurveyController : Controller
    {
        ProductDBEntities _context = new ProductDBEntities();
        [Authorize]
        public ActionResult Index()
        {
               var  model = _context.TblSurveys.ToList(); ;
                return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(TblSurvey model)
        { 
            _context.TblSurveys.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index",model);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.TblSurveys.Where(x => x.SurveyId == id).FirstOrDefault();
            return View(data);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(TblSurvey model,int id)
        {
            var data = _context.TblSurveys.Where(x => x.SurveyId == model.SurveyId).FirstOrDefault();
            if(data != null)
            {
                data.Title = model.Title;
                data.FromDate = model.FromDate;
                data.ToDate = model.ToDate;
                data.CreatedBy = model.CreatedBy;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var data = _context.TblSurveys.SingleOrDefault(x => x.SurveyId == id);
            _context.TblSurveys.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index",data);
        }
    }
}