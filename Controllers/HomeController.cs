using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.Models;
using Homework5.ViewModels;

namespace Homework5.Controllers
{
    public class HomeController : Controller
    {
        Service instance = new Service();
        BookViewModel viewModel = null;
        BorrowsViewModel borrowsViewMOdel = null;
        StudentViewModel studentViewModel = null;
        public ActionResult Index()
        {
            viewModel = new BookViewModel
            {
                Books = instance.getBooks(),
                Authors = instance.getAuthors(),
                BookTypes = instance.GetBookTypes(),
                Borrows = instance.GetBorrows()
            };
            return View(viewModel);
        }
        public ActionResult BookDetail(int id)
        {
            borrowsViewMOdel = new BorrowsViewModel
            {
                
                Book = instance.getBook(id),
                Borrows = instance.GetBorrows(id),
                Students = instance.getStudents()
            };
            return View(borrowsViewMOdel);
        }

        public ActionResult StudentView(int id)
        {
            studentViewModel = new StudentViewModel
            {
                bookId = id,
                classes = instance.getClass(),
                Students = instance.getStudents()
            };
            
            return View(studentViewModel);
        }

        public ActionResult ComplexSearch(string bookName, string type, string author)
        {
            viewModel = new BookViewModel
            {
                Books = instance.getBooks(bookName, type, author),
                Authors = instance.getAuthors(),
                BookTypes = instance.GetBookTypes(),
                Borrows = instance.GetBorrows()
            };
            return View(viewModel);
        }

        public ActionResult searchStudentView(string name, string classNumber)
        {
            studentViewModel = new StudentViewModel
            {
                
                classes = instance.getClass(),
                Students = instance.getStudents(name, classNumber)
            };

            return View(studentViewModel);
        }

    }
}