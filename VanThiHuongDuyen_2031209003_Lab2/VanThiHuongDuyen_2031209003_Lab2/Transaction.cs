using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    public abstract class Transaction
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public Member Member { get; set; }
        public Transaction(string transactionID, DateTime date, Member member)
        {
            TransactionID = transactionID;
            TransactionDate = date;
            Member = member;
        }

        public abstract void Execute();
    }

    public class BorrowTransaction : Transaction
    {
        public Book BookBorrowed { get; set; }
        public BorrowTransaction(string id, DateTime date, Member member, Book book) : base(id, date, member)
        {
            BookBorrowed = book;
        }


        public override void Execute()
        {
            Console.WriteLine($"{Member.Name} borrowed {BookBorrowed.Title}");
        }
    }

    public class ReturnTransaction : Transaction
    {
        public Book BookReturned { get; set; }
        public ReturnTransaction(string id, DateTime date, Member member, Book book) : base(id, date, member)
        {
            BookReturned = book;
        }

        public override void Execute()
        {
            Console.WriteLine($"{Member.Name} borrowed {BookReturned.Title}");
        }
    }
}
