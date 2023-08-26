using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LINQ_STD.Models
{
    public class Student
    {
        [Key]
        public int Student_Number { get; set; }

        [StringLength(50)]
        public string Student_Name { get; set; }

        [StringLength(50)]
        public string Student_Surname { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}