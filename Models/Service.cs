using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Homework5.ViewModels;

namespace Homework5.Models
{
    public class Service
    {
        private SqlConnection currConnection = new SqlConnection("Data Source =.; Initial Catalog = Library; Integrated Security = True");

        public List<Book> getBooks()
        {
            
            List<Book> books = new List<Book>();
           
            string sqlQuery = "select * from books";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book theBooks = new Book();
                    theBooks.bookId = Convert.ToInt32(reader["bookId"]);
                    if(bookAvailable(Convert.ToInt32(reader["bookId"])))
                    {
                        theBooks.status = "Available";
                    }
                    else
                    {
                        theBooks.status = "Out";
                    }
                    theBooks.bookName = Convert.ToString(reader["name"]);
                    theBooks.pageCount = Convert.ToInt32(reader["pagecount"]);
                    theBooks.Points = Convert.ToInt32(reader["point"]);
                    theBooks.authorId = Convert.ToInt32(reader["authorId"]);
                    theBooks.typeId = Convert.ToInt32(reader["typeId"]);
                    books.Add(theBooks);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return books;
        }

        public List<Author> getAuthors()
        {

            List<Author> authors = new List<Author>();

            string sqlQuery = "select * from authors";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Author Authors = new Author();
                    Authors.authorId = Convert.ToInt32(reader["authorId"]);
                    Authors.Name = Convert.ToString(reader["name"]);
                    Authors.Surname = Convert.ToString(reader["surname"]);
                    authors.Add(Authors);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return authors;
        }

        public List<BookType> GetBookTypes()
        {

            List<BookType> bookTypes = new List<BookType>();

            string sqlQuery = "select * from types";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookType bookType = new BookType();
                    bookType.typeID = Convert.ToInt32(reader["typeId"]);
                    bookType.Name = Convert.ToString(reader["name"]);
                    bookTypes.Add(bookType);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return bookTypes;
        }

        public List<Borrow> GetBorrows()
        {

            List<Borrow> borrows = new List<Borrow>();

            string sqlQuery = "select * from borrows";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Borrow Borrows = new Borrow();
                    Borrows.borrowId = Convert.ToInt32(reader["borrowId"]);
                    Borrows.studentId = Convert.ToInt32(reader["studentId"]);
                    Borrows.bookId = Convert.ToInt32(reader["bookId"]);
                    Borrows.takenDate = (DateTime)reader["takenDate"];
                    Borrows.broughtDate = (DateTime)reader["broughtDate"];
                    borrows.Add(Borrows);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return borrows;
        }

        public Book getBook(int id)
        {

            Book theBook = new Book();

            string sqlQuery = "select * from books where bookId = " + id;
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                theBook = new Book();
                theBook.bookId = Convert.ToInt32(reader["bookId"]);
                theBook.bookName = Convert.ToString(reader["name"]);
                theBook.pageCount = Convert.ToInt32(reader["pagecount"]);
                theBook.Points = Convert.ToInt32(reader["point"]);
                theBook.authorId = Convert.ToInt32(reader["authorId"]);
                theBook.typeId = Convert.ToInt32(reader["typeId"]);
              
                
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return theBook;
        }

        public List<Borrow> GetBorrows(int id)
        {

            List<Borrow> borrows = new List<Borrow>();

            string sqlQuery = "select * from borrows where bookId = " + id;
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Borrow Borrows = new Borrow();
                    Borrows.borrowId = Convert.ToInt32(reader["borrowId"]);
                    Borrows.studentId = Convert.ToInt32(reader["studentId"]);
                    Borrows.bookId = Convert.ToInt32(reader["bookId"]);
                    Borrows.takenDate = (DateTime)reader["takenDate"];
                    Borrows.broughtDate = (DateTime)reader["broughtDate"];
                    borrows.Add(Borrows);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return borrows;
        }

        public List<Student> getStudents()
        {

            List<Student> students = new List<Student>();

            string sqlQuery = "select * from students";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.studentID = Convert.ToInt32((reader["studentId"]));
                    student.Name = Convert.ToString(reader["name"]);
                    student.Surname = Convert.ToString(reader["surname"]);
                    student.BirthDate = (DateTime)(reader["birthdate"]);
                    student.Gender = Convert.ToString(reader["gender"]);
                    student.Class = Convert.ToString(reader["class"]);
                    student.Point = Convert.ToInt32((reader["point"]));
                    
                    students.Add(student);
                }
                
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return students;
        }

        public List<string> getClass()
        {

            List<string> classes = new List<string>();

            string sqlQuery = "select distinct class from students";
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string theclass = "";
                    theclass = Convert.ToString(reader["class"]);
                    classes.Add(theclass);
                }

            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return classes;
        }

        public List<Book> getBooks(string bookName, string type, string author )
        {
            string sqlQuery = "";
            List<Book> searchedBooks = new List<Book>();

            if(bookName == "" && type == "0" && author == "0") // No search terms
            {
                sqlQuery = "select * from books";
            }
            else if(bookName != "" && type == "0" && author == "0") // Only bookName given
            {
                sqlQuery = "select * from books where name LIKE '%" + bookName + "%'";
            }
            else if (bookName == "" && type != "0" && author != "0") // Only type given
            {
                sqlQuery = "select * from books where typeId = " + type;
            }
            else if (bookName == "" && type != "0" && author != "0") // Only author given
            {
                sqlQuery = "select * from books where authorId = " + author;
            }
            else if (bookName != "" && type != "0" && author == "0") // bookName and Type given
            {
                sqlQuery = "select * from books where name LIKE '%" + bookName + "%' AND typeId = " + type + "";
            }
            else if (bookName != "" && type != "0" && author == "0") // bookName and author given
            {
                sqlQuery = "select * from books where name LIKE '%" + bookName + "%' AND authorId = " + author + "";
            }
            else if (bookName != "" && type != "0" && author == "0") // type and author given
            {
                sqlQuery = "select * from books where typeId = " + type + " AND authorId = " + author + "";
            }
            else if (bookName != "" && type != "0" && author != "0") // bookName and Type and author given
            {
                sqlQuery = "select * from books where name LIKE '%" + bookName + "%' AND typeId = " + type + " AND authorId = " + author + "";
            }
            
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book theBooks = new Book();
                    theBooks.bookId = Convert.ToInt32(reader["bookId"]);
                    theBooks.bookName = Convert.ToString(reader["name"]);
                    theBooks.pageCount = Convert.ToInt32(reader["pagecount"]);
                    theBooks.Points = Convert.ToInt32(reader["point"]);
                    theBooks.authorId = Convert.ToInt32(reader["authorId"]);
                    theBooks.typeId = Convert.ToInt32(reader["typeId"]);
                    searchedBooks.Add(theBooks);
                }
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message;
            }
            finally
            {
                currConnection.Close();
            }

            return searchedBooks;
        }

        public List<Student> getStudents(string name, string classNumber)
        {
            string sqlQuery = "";  
            List<Student> searchedStudents = new List<Student>();

            if(name == "" && classNumber == "")
            {
                sqlQuery = "select * from students";
            }
            else if(name != "" && classNumber == "")
            {
                sqlQuery = "select * from students Where name LIKE '%" + name + "%'";
            }
            else if(name == "" && classNumber != "")
            {
                sqlQuery = "select * from students Where class = '" + classNumber +"'";
            }
            else if(name != "" && classNumber != "")
            {
                sqlQuery = "select * from students Where class = '" + classNumber + "' AND name LIKE '%" + name + "%'";
            }

         
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.studentID = Convert.ToInt32((reader["studentId"]));
                    student.Name = Convert.ToString(reader["name"]);
                    student.Surname = Convert.ToString(reader["surname"]);
                    student.BirthDate = (DateTime)(reader["birthdate"]);
                    student.Gender = Convert.ToString(reader["gender"]);
                    student.Class = Convert.ToString(reader["class"]);
                    student.Point = Convert.ToInt32((reader["point"]));

                    searchedStudents.Add(student);
                }

            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message; // Couldn't get viewbag.message to work
            }
            finally
            {
                currConnection.Close();
            }

            return searchedStudents;
        }

        public void BorrowBook(int bookId, int studentId)
        {
            string sqlQuery = "INSERT INTO borrows (studentId, bookId, takenDate) VALUES(" + studentId + "," + bookId + "," + System.DateTime.Now + ")";
            try
            {
                currConnection.Open();      
                SqlCommand command = new SqlCommand(sqlQuery, currConnection);
                command.ExecuteNonQuery();
                currConnection.Close();
                
            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message;
            }
            finally
            {
                currConnection.Close();
            }

        }

        public void ReturnBook(int bookId)
        {
            String sqlQuery = "select TOP 1 borrowId from borrows where bookId = " + bookId + " order by takenDate DESC";
            int borrowId = 0;
            bool status = false;
            try
            {
                currConnection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                borrowId = Convert.ToInt32((reader["borrowId"]));
            }
            catch (Exception err)
            {
                status = false;
            }
            finally
            {
                currConnection.Close();
            }

            //sqlQuery = "INSERT INTO borrows (studentId, bookId, takenDate) VALUES(" + studentId + "," + bookId + "," + System.DateTime.Now + ")"; 
            // Wanted to insert broughtdate back into database
            try
            {
                currConnection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, currConnection);
                command.ExecuteNonQuery();
                currConnection.Close();

            }
            catch (Exception err)
            {
                string Message = "Error: " + err.Message;
            }
            finally
            {
                currConnection.Close();
            }


        }


        public bool bookAvailable(int id)
        {
            bool available = true;

            string sqlQuery = "select TOP 1 borrowId from borrows where bookId = " + id + " order by takenDate DESC";

            //try
            //{
            //    currConnection.Open();
            //    SqlCommand cmd = new SqlCommand(sqlQuery, currConnection);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    reader.Read();
            //    if(reader["broughtDate"] == DBNull.Value)
            //    {
            //        available = false;
            //    } 
            //}
            //catch (Exception err)
            //{
            //    string Message = "Error: " + err.Message; 
            //}
            //finally
            //{
            //    currConnection.Close();
            //}

            return available;
        }

    }
}


