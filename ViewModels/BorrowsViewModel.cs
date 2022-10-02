using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework5.Models;

namespace Homework5.ViewModels
{
    public class BorrowsViewModel
    {
        
        public Book Book { get; set; }
        public List<Borrow> Borrows { get; set; }
        public List<Student> Students { get; set; }
    }
}