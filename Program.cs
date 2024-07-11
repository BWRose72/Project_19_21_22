using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_19_21_22
{
    class Program
    {
        const string filePath = "../../books.txt";
        static List<Book> books = new List<Book>();
       
        static void Main(string[] args)
        {
            
            Console.Title = "Library";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            LoadBooks();          
            ShowMenu();
            
        }

        public static void AddBook()
        {
            Console.Write("Enter ISBN: ");
            var isbn = Console.ReadLine();
            Console.Write("Enter title: ");
            var title = Console.ReadLine();
            Console.Write("Enter author: ");
            var author = Console.ReadLine();
            Console.Write("Enter year: ");
            if (!int.TryParse(Console.ReadLine(), out var year))
            {
                Console.WriteLine("Invalid year. Please try again.");
                return;
            }
            Console.Write("Enter price: ");
            if (!double.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price. Please try again.");
                return;
            }

            books.Add(new Book(isbn, title, author, year, (decimal)price));
            SaveBooks();
            Console.WriteLine("Book added successfully.");
            Wait();
        }

        public static void SaveBooks()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using (writer)
            {
                foreach (Book currBook in books)
                {
                    writer.WriteLine(currBook.ToString());
                }
            }
        }

        public static void LoadBooks()
        {
            StreamReader reader = new StreamReader(filePath, Encoding.Unicode);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] props = line.Split('/').ToArray();
                    books.Add(new Book(props[0], props[1], props[2], int.Parse(props[3]), decimal.Parse(props[4]), bool.Parse(props[5]), props[6]));
                }
            }
        }

        public static void AddingBook()
        {
            Console.WriteLine("-------------------------------");
            Console.Write("Enter ISBN: ");
            var isbn = Console.ReadLine();
            Console.Write("Enter title: ");
            var title = Console.ReadLine();
            Console.Write("Enter author: ");
            var author = Console.ReadLine();
            Console.Write("Enter year: ");
            if (!int.TryParse(Console.ReadLine(), out var year))
            {
                Console.WriteLine("Invalid year. Please try again.");
                return;
            }
            Console.Write("Enter price: ");
            if (!double.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price. Please try again.");
                return;
            }

          if (price <= 0 && year > 2024)
            {
                Console.WriteLine("Invalid price and year. Please try again");
                return;               
            }
          else if (year > 2024)
            {
                Console.WriteLine("Invalid year. Please try again.");
                return;
            }
            else if (price <= 0)
            {
                Console.WriteLine("Invalid price. Please try again.");
                return;
            }

          
            books.Add(new Book(isbn, title, author, year, (decimal)price));
            SaveBooks();
            Console.WriteLine("Book added successfully.");
            Console.WriteLine("-------------------------------");
            Wait();
        }

        public static void BorrowBook()
        {
            ListAvailableBooks();
            Console.WriteLine("-------------------------------");
            Console.Write("Enter the ISBN of the book you want to borrow: ");
            string isbn = Console.ReadLine();
            Book selectedBook = null;
            foreach (Book book in books)
            {
                if (book.Isbn == isbn && book.Availability)
                {
                    selectedBook = book;
                    break;
                }
            }
         

            if (selectedBook == null)
            {
                Console.WriteLine("Book not found or not available.");
                return;
            }
                   
            Console.Write("Enter borrower's name: ");
            string borrower = Console.ReadLine();

            if (borrower.Length < 2)
            {
                Console.WriteLine("Error. There is only one entered letter. Please add name.");
                return;
            }
            else
            {
                Console.WriteLine();
                
            }

            selectedBook.BorrowBook(borrower);

            SaveBooks();

            Console.WriteLine("Book borrowed successfully.");
            Console.WriteLine("-------------------------------");
            Wait();
        }

        public static void ReturnBook()
        {
            Console.WriteLine("-------------------------------");
            ListBorrowedBooks();
            Console.Write("Enter the ISBN of the book you want to return: ");
            string isbn = Console.ReadLine();

            Book selectedBook = null;
            foreach (Book book in books)
            {
                if (book.Isbn == isbn && !book.Availability)
                {
                    selectedBook = book;
                    break;
                }
            }

            if (selectedBook == null)
            {
                Console.WriteLine("Book not found or not borrowed.");
                return;
            }

            selectedBook.ReturnBook();

            SaveBooks();

            Console.WriteLine("Book returned successfully.");
            Console.WriteLine("-------------------------------");
            Wait();
        }

        public static void ListAvailableBooks()
        {
            foreach (Book book in books)
            {
                if (book.Availability)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"ISBN: {book.Isbn}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Year: {book.Year}");
                    Console.WriteLine($"Price: {book.Price} BGN");
                    Console.WriteLine("-------------------------------");
                    
                } 
                
            }
            Wait();
        }

        public static void ListBorrowedBooks()
        {
            foreach (Book book in books)
            {
                if (!book.Availability)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"ISBN: {book.Isbn}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Year: {book.Year}");
                    Console.WriteLine($"Price: {book.Price} BGN");
                    Console.WriteLine($"Borrowed by: {book.Borrower}");
                    Console.WriteLine("-------------------------------");
                }
               
            }
            Wait();
        }
       
        public static void ShowMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. Borrow a book");
                Console.WriteLine("3. Return a book");
                Console.WriteLine("4. List available books");
                Console.WriteLine("5. List borrowed books");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
              
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddingBook();
                        break;
                    case "2":
                        BorrowBook();
                        break;
                    case "3":
                        ReturnBook();
                        break;
                    case "4":
                        ListAvailableBooks();
                        break;
                    case "5":
                        ListBorrowedBooks();
                        break;
                    case "6":
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            
        }

        public static void Wait()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            ShowMenu();
        }
    }
}
