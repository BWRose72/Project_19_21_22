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
        public int Year {
            get { return year; }
            private set {
                if (value > DateTime.Now.Year)
                    throw new ArgumentException(""); //todo: write a msg for time-travellers
                year = value;
            }
        }
        public double Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(""); //todo: write a msg for free-givers
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

        /// <summary>
        /// Променя статута на книгата от Налична в Неналична и записва името на заемателя.
        /// </summary>
        /// <param name="borrowerName">Името на заемателя.</param>
        public void BorrowBook(string borrowerName)
        {
            Availability = false;
            Borrower = borrowerName;
        }

        /// <summary>
        /// Променя статута на книгата от Неналична в Налична и изтрива името на заемателя.
        /// </summary>
        public void ReturnBook()
        {
            Availability = true;
            Borrower = "";
        }

        /// <summary>
        /// Извежда информацията за книгата. София и Преслава, не пишете нищо в скобичките.
        /// </summary>
        /// <param name="fileFormat">Ако е "false" всяко свойство ще е на нов ред. </param>
        /// <returns></returns>
        public string ToString(bool fileFormat = false)
        {
            string result = "";
            if (fileFormat)
            {
                result = $"{Isbn}/{Title}/{Author}/{Year}/{Price}/{Availability}/{Borrower}";
            }
            else
            {
                result += "Идентификатор: " + Isbn + "\nЗаглавие: " + Title + "\nАвтор: " + Author + "\nГодина на излизане: " + Year + "\nЦена: " + Price + " лева\n";
                if (Availability)
                    result += "Налична е.";
                else
                    result += "Не е налична.\nВзета е от: " + Borrower;
            }
            return result;
        }
    }
}
