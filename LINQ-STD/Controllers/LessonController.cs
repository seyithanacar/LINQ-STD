using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LINQ_STD.Models;

namespace LINQ_STD.Controllers
{
    public class LessonController : Controller
    {
        Context c = new Context();
        public ActionResult Lesson_Index()
        {
            var control = c.Lessons.ToList();
            return View(control);
        }
        public ActionResult Add_Lesson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Lesson(Lesson l)
        {
            c.Lessons.Add(l);
            c.SaveChanges();
            return RedirectToAction("Lesson_Index");
        }
        public ActionResult Delete_Lesson (int id){
            var control = c.Lessons.Find(id);
            c.Lessons.Remove(control);
            c.SaveChanges();
            return RedirectToAction("Lesson_Index");
        }
        [HttpGet]
        public ActionResult Update_Lesson(int id) {
            var lesson = c.Lessons.Find(id);
            return View(lesson);
        }
        [HttpPost]
        public ActionResult Update_Lesson(Lesson lesson) {
            var l = c.Lessons.Find(lesson.Lesson_Id);
            l.Lesson_Name = lesson.Lesson_Name;
            l.Lesson_Id = lesson.Lesson_Id;
            c.SaveChanges();
            return RedirectToAction("Lesson_Index");
        }
    }
}