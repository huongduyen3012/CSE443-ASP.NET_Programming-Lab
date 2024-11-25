using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }

        // Parameterless constructor
        public Library()
        {
            LibraryName = "Default Library";
            Books = new List<Book>();
            Members = new List<Member>();
        }

        // Parameterized constructor
        public Library(string libraryName, List<Book> books)
        {
            LibraryName = libraryName;
            Books = books;
            Members = new List<Member>();
        }

        // Copy constructor
        public Library(Library existingLibrary)
        {
            LibraryName = existingLibrary.LibraryName;
            Books = new List<Book>(existingLibrary.Books);
            Members = new List<Member>(existingLibrary.Members);
        }

        // Method to display library information
        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library Name: {LibraryName}");
            Console.WriteLine($"Number of Books: {Books.Count}");
            Console.WriteLine($"Number of Members: {Members.Count}");
        }
    }
}
