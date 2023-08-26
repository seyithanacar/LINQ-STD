using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LINQ_STD.Models
{
    public class Note
    {
        [Key]
        public int Note_Id { get; set; }
        public int Note_Average { get; set; }
        public int Note_1 { get; set; }
        public int Note_2 { get; set; }
        public bool Statu { get; set; }
        public int Lesson_Id { get; set; }
        public virtual Lesson Lesson { get; set; }


        public int Student_Number { get; set; }
        public virtual Student Student { get; set; }
    }
}