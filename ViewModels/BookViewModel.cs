using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework5.Models;

namespace Homework5.ViewModels
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<BookType> BookTypes { get; set; }
        public List<Borrow> Borrows { get; set; }
    }
}

