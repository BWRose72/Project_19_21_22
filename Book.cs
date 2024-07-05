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

        }

    }
}
