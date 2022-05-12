using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryETDBFIrst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ex5();
            Console.ReadKey();
        }

        public static void ex1()//find debtors
        {
            using (var library = new LibraryEntities())
            {
                var answer = library.Books.Where(x => x.ReaderID != null).Select(a => a.ReaderID);
                var reader = library.Readers.Where(x => answer.Any(y => x.ReaderID == y));



                foreach (var reader1 in reader)
                {
                    Console.WriteLine(reader1.Name);
                }


            }

        }

        public static void ex2()//find authors of selected book
        {
            using (var context = new LibraryEntities())
            {
                var allBooks = context.Books.Select(x => new {x.BookID,x.Name}).ToList();


                foreach (var allBook in allBooks)
                {
                    Console.WriteLine(allBook.BookID + " " + allBook.Name);
                    
                }

                Console.WriteLine("Select BookId");
                var bookId = int.Parse(Console.ReadLine());

                var authors = context.AuthorBooks.Where(x => x.BookID == bookId).Select(x => x.AuthorID).ToList();
                var authorsName = context.Authors.Where(x => authors.Any(y => x.AuthorID == y)).Select(x => x.Name).ToList();

                foreach (var authorName in authorsName)
                {
                    Console.WriteLine(authorName);
                }




            }
        }

        public static void ex3()//availible books
        {
            using (var context = new LibraryEntities())
            {
                var avalibleBook = context.Books.Where(x => x.ReaderID == null).Select(x => x.Name).ToList();
                foreach (var book in avalibleBook)
                {
                    Console.WriteLine(book);
                }


            }
        }

        public static void ex4()//books on hand 
        {
            using (var context=new LibraryEntities())
            {
                var readers = context.Readers.Select(x =>new {x.ReaderID,x.Name}).ToList();

                Console.WriteLine("Enter Reader ID");

                foreach (var reader in readers)
                {
                    Console.WriteLine(reader.ReaderID + " " + reader.Name);
                }

                var readerId = int.Parse(Console.ReadLine());

                var books = context.Books.Where(x => x.ReaderID == readerId).Select(x => x.Name).ToList();
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }

            
        }

        public static void ex5()//release all debts
        {
            using (var context =new LibraryEntities())
            {
                var debtodrs = context.Books.Where(x => x.ReaderID != null);
                
                foreach (var debtord in debtodrs)
                {
                    debtord.ReaderID = null;
                    
                }

                Console.WriteLine("released");
                context.SaveChanges();
            }

        }
    }
}
