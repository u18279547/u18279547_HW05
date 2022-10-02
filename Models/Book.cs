using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public int pageCount { get; set; }
        public int Points { get; set; }
        public int authorId { get; set; }
        public int typeId { get; set; }
        public string status { get; set; }
    }
}