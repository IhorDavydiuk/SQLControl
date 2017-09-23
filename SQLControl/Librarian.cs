using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB;

namespace SQLControl
{
    class Librarian
    {
            DatabaseOperation operatinLIbrarion;
            public Librarian()
            {
            operatinLIbrarion = new DatabaseOperation(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
            }
        public void FindBooksAuthor(string nameAuthor)
        {
            operatinLIbrarion.SelectStrange("Book", "Author",nameAuthor);
        }
        public void FindBooksGenre(string nameGenre)
        {
            operatinLIbrarion.SelectStrange("Book", "Genre", nameGenre);
        }
        public void FindBooksYear(string nameYear)
        {
            operatinLIbrarion.SelectStrange("Book", "Year", nameYear);
        }
        public void AddBooks(string nameTable, string nameAuthor, string nameGenre, string nameYear)
        {
            operatinLIbrarion.Insert(nameTable, $"'{nameAuthor}'", $"'{nameGenre}'", $"'{nameYear}'", "1");
        }
        public void RemoveBooks(string nameTable,string nameAuthor)
        {
            operatinLIbrarion.Delete(nameTable, "Author", $"'{nameAuthor}'");
        }
    }
}
