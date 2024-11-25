using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    class LibraryWithEvents
    {
        public event Action<Book, Member> OnBookBorrowed;

        public void BorrowedBook(Book book, Member member)
        {
            Console.WriteLine($"{member.Name} borrowed {book.Title}.");
            OnBookBorrowed?.Invoke(book, member);
        }
    }

    class NotificationServiceWithEvents
    {
        public void OnBookBorrowed(Book book, Member member)
        {
            Console.WriteLine($"Notification: {member.Name} borrowed {book.Title}.");
        }
    }
}

