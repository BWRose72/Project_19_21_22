using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_19_21_22
{
    class Book
    {
        private int year;
        private double price;

        public string Isbn { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year
        {
            get { return year; }
            private set
            {
                if (value > DateTime.Now.Year)
                    throw new ArgumentException("Cannot set a year later than the current year.");
                year = value;
            }
        }
        public double Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("The price cannot be zero or negative.");
                price = value;
            }
        }
        public bool Availability { get; private set; }
        public string Borrower { get; private set; }

        public Book(string isbn, string title, string author, int year, double price, bool availability = true, string borrower = "")
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            Year = year;
            Price = price;
            Availability = availability;
            Borrower = borrower;
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
            return $"{Isbn}/{Title}/{Author}/{Year}/{Price}/{Availability}/{Borrower}";
        }
    }
}
