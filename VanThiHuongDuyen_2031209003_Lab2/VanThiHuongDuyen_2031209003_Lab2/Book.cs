using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    public class Book: IPrintable
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Year cannot be less than 0");
                    return;
                }
                year = value;
            }
        }
        private int copiesAvailable;
        public int CopiesAvailable
        {
            get { return copiesAvailable; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Copies Available cannot be less than 0");
                    return;
                }
                copiesAvailable = value;
            }
        }

        public Book(string isbn, string title, string author, int year, int copiesAvailable)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Year = year;
            CopiesAvailable = copiesAvailable;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}\nTitle: {Title}\nAuthor: {Author}\nYear: {Year}\nCopies Available: {CopiesAvailable} ");
        }

        public void PrintDetails()
        {
            Console.WriteLine($"ISBN: {ISBN}, Title: {Title}, Author: {Author}");
        }
    }
}
