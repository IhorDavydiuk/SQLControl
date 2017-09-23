using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB;
using System.IO;

namespace SQLControl1
{
    class Visitor
    {
        DatabaseOperation operatinVisitor;
        public Visitor()
        {
            operatinVisitor = new DatabaseOperation(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
        }
        public void Take(string nameAuthor)
        {
            operatinVisitor.Update("tabl1","IsReturn","0","Author",nameAuthor);
        }
        public void Return(string nameAuthor)
        {
            operatinVisitor.Update("tabl1", "IsReturn", "1", "Author", nameAuthor);
        }
        public void ViewBorrowedBooks()
        {
            operatinVisitor.SelectColumn("tabl1", "Author");
        }
    }
}
