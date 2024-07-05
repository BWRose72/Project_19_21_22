using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_19_21_22
{
    class Book
    {
        public string Isbn { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public double Price { get; private set; }
        public bool Availability { get; private set; }
        public string Borrower { get; private set; }

        public Book(string isbn, string title, string author, int year, double price)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Year = year;
            Price = price;
            Availability = true;
            Borrower = "";
        }

        public void BorrowBook(string borrowerName)
        {
            Availability = false;
            Borrower = borrowerName;
        }

        public void ReturnBook()
        {
            Availability = true;
            Borrower = "";
        }

        public override string ToString()
        {
            string result = "";
            result += "Идентификатор: " + Isbn + "\nЗаглавие: " + Title + "\nАвтор: " + Author + "\nГодина на излизане: " + Year + "\nЦена: " + Price + " лева\n";
            if (Availability)
                result += "Налична е.";
            else
                result += "Не е налична. Взета е от: " + Borrower;
            return result;
        }
    }
}
