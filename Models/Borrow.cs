using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Borrow
    {
        public int borrowId { get; set; }
        public int studentId { get; set; }
        public int bookId { get; set; }
        public DateTime takenDate { get; set; }
        public DateTime broughtDate { get; set; }
    }
}