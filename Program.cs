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

        }

        //Записва информацията от "books" във файла
        public static void SaveBooks()
        {
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.Unicode);
            using(writer)
            {
                foreach ( Book currBook in books)
                {
                    writer.WriteLine(currBook.ToString(true));
                }
            }
        }

        //Записва информацията от файла в "books"
        public static void LoadBooks()
        {
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] props = line.Split('/').ToArray();
                    books.Add(new Book(props[0], props[1], props[2], int.Parse(props[3]), double.Parse(props[4]), bool.Parse(props[5]), props[6]));
                }
            }
        }

        //Добавяне на нова книга в библиотеката
        public static void AddBook()
        {
            throw new NotImplementedException();
        }

        //Заемане на книгата от читател
        public static void BorrowBook()
        {
            throw new NotImplementedException();
        }

        //Връщане на книгата от читател
        public static void ReturnBook()
        {
            throw new NotImplementedException();
        }

        //Справка за налични книги
        public static void ListAvailableBooks()
        {
            throw new NotImplementedException();
        }

        //Справка за заетите книги и техните заематели
        public static void ListBorrowedBooks()
        {
            throw new NotImplementedException();
        }
    }
}
