using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework5.Models;

namespace Homework5.ViewModels
{
    public class StudentViewModel
    {
        public int bookId { get; set; }
        public List<string> classes { get; set; }

        public List<Student> Students { get; set; }
    }
}