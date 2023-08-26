using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LINQ_STD.Models;
using System.Web.Mvc;

namespace LINQ_STD.Controllers
{
    public class NoteController : Controller
    {
        Context c = new Context();
        public ActionResult Note_Index()
        {
            var notes = c.Notes.ToList();
            return View(notes);
        }
        public ActionResult Add_Note (){ 
        return View();
        }
        [HttpPost]
        public ActionResult Add_Note(Note n) {
            n.Note_Average = (n.Note_1 + n.Note_2) / 2;
            if (n.Note_Average >= 50)
                n.Statu = true;
            else
                n.Statu = false;
            c.Notes.Add(n);
            c.SaveChanges();
            return RedirectToAction("Note_Index"); 
        }
        public ActionResult Delete_Note(int id){
            var control = c.Notes.Find(id);
            c.Notes.Remove(control);
            c.SaveChanges();
            return RedirectToAction("Note_Index");
        }
        public ActionResult Update_Note(int id) {
            var n = c.Notes.Find(id);
            return View(n);
        }
        [HttpPost]
        public ActionResult Update_Note(Note n) {
            var new_n = c.Notes.Find(n.Note_Id);
            new_n.Note_1 = n.Note_1;
            new_n.Note_2 = n.Note_2;
            
            new_n.Student_Number = n.Student_Number;
            new_n.Lesson_Id = n.Lesson_Id;
            new_n.Note_Average=(new_n.Note_1+new_n.Note_2)/ 2;
            if (new_n.Note_Average >= 50)
                new_n.Statu = true;
            else
            {
                new_n.Statu = false;
            }
            c.SaveChanges();
            return RedirectToAction("Note_Index");
        }
        
    }
} 