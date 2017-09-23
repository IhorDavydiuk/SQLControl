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
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseOperation operatinLibrarian = new DatabaseOperation(ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString);
            Visitor visitor = new Visitor();
            do
            {
                Console.WriteLine(@"Select your action:
1 - Borrow book
2 - Return book
3 - View borrowed books");
                Console.Write("Enter: ");

                switch ((int.Parse(Console.ReadLine())))
                {
                    case 1:
                        {
                            Console.Write("Enter name author: ");
                            visitor.Take($"'{Console.ReadLine().Trim()}'");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter name author: ");
                            visitor.Return($"'{Console.ReadLine().Trim()}'");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine();
                            visitor.ViewBorrowedBooks();
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
