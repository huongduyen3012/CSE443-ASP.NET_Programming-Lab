using System;
using System.Net;
using System.Reflection;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Exercise 1-5
            Member member1 = new Member("M1", "Alice", "alice@mail.com");
            Member member2 = new Member("M2", "Bob", "bob@mail.com");
            member1.DisplayInfo();

            Console.WriteLine("-------------------");

            Book book1 = new Book("123", "C# Programming", "John Doe", 2020, 3);
            Book book2 = new Book("124", "Java Programming", "Jane Doe", 2019, 5);
            book2.DisplayInfo();

            Console.WriteLine("-------------------");

            BorrowTransaction borrowTransaction = new BorrowTransaction("T1", DateTime.Now, member1, book1);
            ReturnTransaction returnTransaction = new ReturnTransaction("T2", DateTime.Now, member2, book2);

            List<Transaction> transactions = new List<Transaction>
            {
                borrowTransaction,
                returnTransaction
            };

            foreach (var transaction in transactions)
            {
                transaction.Execute();
            }

            Console.WriteLine("-------------------");
            //Exercise 6
            List<Book> books = new List<Book> { book1, book2 };

            Library library = new Library("EIU Library", books);
            library.DisplayLibraryInfo();

            Console.WriteLine("-------------------");

            //Exercise 7
            NotificationService notificationService = new NotificationService();
            notificationService.SendNotification("Hello, My name is Anna");
            AdvancedNotificationService advance = new AdvancedNotificationService();
            advance.SendNotification("Nice to meet you");

            Console.WriteLine("-------------------");

            //Exercise 8
            LibraryCard libraryCard = new LibraryCard("01", member1);
            libraryCard.RenewCard();

            Console.WriteLine("-------------------");

            //Exercise 9
            BookClass bookClass1 = new BookClass("111", "C# Programming", "Alice");
            BookClass bookClass2 = new BookClass("111", "C# Programming", "Alice");

            Console.WriteLine("Compared in class: " + (bookClass1 == bookClass2));
            //In class, the == operator compare reference by default, bookClass1 and bookClass2 are two difference objects in memory
            //so the result is false

            BookRecord bookRecord1 = new BookRecord("111", "C# Programming", "Alice");
            BookRecord bookRecord2 = new BookRecord("111", "C# Programming", "Alice");

            Console.WriteLine("Compared in record: " + (bookRecord1 == bookRecord2));
            //In record, the == operator compare the values of all properties, bookRecord1 and bookRecord2 have same values
            //so the result is true

            BookRecord bookRecord3 = bookRecord1 with { Title = "Advanced C#" };
            Console.WriteLine($"Initial properties: {bookRecord1.ISBN}, {bookRecord1.Title}, " +
                $"{bookRecord1.Author}\nCopied properties: {bookRecord3.ISBN}, " +
                $"{bookRecord3.Title}, {bookRecord3.Author} ");

            Console.WriteLine("-------------------");

            //Exercise 10
            LibraryWithEvents library1 = new LibraryWithEvents();
            NotificationServiceWithEvents notificationServiceWithEvents = new NotificationServiceWithEvents();

            library1.OnBookBorrowed += notificationServiceWithEvents.OnBookBorrowed;

            Book book = new Book("123", "C# Programming", "John Doe", 2020, 3);
            Member member = new Member("M0", "Bob", "bob@mail.com");

            library1.BorrowedBook(book, member);
        }
    }
}
