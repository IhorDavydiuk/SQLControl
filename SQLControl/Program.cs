using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WorkWithDB;

namespace SQLControl
{

    public class Program
    {
        static void Main(string[] args)
        {
            DatabaseOperation operatinLibrarian = new DatabaseOperation(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
            operatinLibrarian.CreateTable("Book", "Author", "NVARCHAR(30)", "Genre", "NVARCHAR(30)", "Year", "DATE", "Returned", "BIT");
            operatinLibrarian.Insert("Book", "'Same Frost'", "'Thriller'", "'1995-10-04'", 1);
            operatinLibrarian.Insert("Book", "'Billy Branch'", "'Story'", "'2000-04-09'", 1);
            operatinLibrarian.Insert("Book", "'Jahn Bist'", "'Detective'", "'1980-03-10'", 1);
            Librarian lb = new Librarian();
            do
            {
                Console.WriteLine(@"Select your action:
1 - Find books by Author
2 - Find books by Genre
3 - Find books by Year
4 - Add books
5 - Remove books");
                Console.Write("Enter: ");
                switch ((int.Parse(Console.ReadLine())))
                {
                    case 1:
                        {
                            Console.Write("Enter name: ");
                            lb.FindBooksAuthor($"'{Console.ReadLine().Trim()}'");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter genre: ");
                            lb.FindBooksGenre($"'{Console.ReadLine().Trim()}'");
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Enter year: ");
                            lb.FindBooksYear($"'{Console.ReadLine().Trim()}'");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter nameTable, nameAuthor, Genre, Year(yyyy-mm-dd) accordingly: ");
                            lb.AddBooks(Console.ReadLine().Trim(), Console.ReadLine().Trim(), Console.ReadLine().Trim(), Console.ReadLine().Trim());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter nameTable, nameAuthor accordingly: ");
                            lb.RemoveBooks(Console.ReadLine().Trim(), Console.ReadLine().Trim());
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Not correct value!!");
                            break;
                        }
                }
                Console.WriteLine();
                Console.Write("Do you want to continue?(y/n) ");
            }
            while (Console.ReadLine().Trim().ToLower() == "y");
            Console.Read();
        }
    }
}