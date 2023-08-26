using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LINQ_STD.Models
{
    public class Lesson
    {
        [Key]
        public int Lesson_Id { get; set; }
        [StringLength(50)]
        public string Lesson_Name { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}