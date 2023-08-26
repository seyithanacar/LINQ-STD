using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LINQ_STD.Models;

namespace LINQ_STD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Context c = new Context();
        public ActionResult Student_Index()
        {
            var control = c.Students.ToList();
            return View(control);
        }
        [HttpGet]
        public ActionResult Add_Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_Student(Student s)
        {
            c.Students.Add(s);
            c.SaveChanges();
            return RedirectToAction("Student_Index");
        }
        public ActionResult Delete_Student(int id)
        {
            var s = c.Students.Find(id);
            c.Students.Remove(s);
            c.SaveChanges();
            return RedirectToAction("Student_Index");
        }
        [HttpGet]
        public ActionResult Update_Student(int id)
        {
            var s = c.Students.FirstOrDefault(x=>x.Student_Number==id);
            
            return View(s);
        }
        [HttpPost]
        public ActionResult Update_Student(Student s)
        {
            var new_s = c.Students.FirstOrDefault(x=>x.Student_Number==s.Student_Number);
            if (new_s != null)
            {
                new_s.Student_Number = s.Student_Number;
                new_s.Student_Name = s.Student_Name;
                new_s.Student_Surname = s.Student_Surname;
                c.SaveChanges();
            }
            
            return RedirectToAction("Student_Index");
        }
        [HttpGet]
        public ActionResult Contains_Ex()
        {

            string aranan = null;

            return View(aranan);
        }
        [HttpPost]
        public ActionResult Contains_Ex(string aranan)
        {
            var degerler = from item in c.Students
                           where item.Student_Name.Contains(aranan) || item.Student_Surname.Contains(aranan)
                           select item.Student_Name;


            return View(degerler.ToList());
        }
    }
}