using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    public class Member : IPrintable, IMemberActions
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Member(string memberID, string name, string email)
        {
            MemberID = memberID;
            Name = name;
            Email = email;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {MemberID}, Name: {Name}, Email: {Email}");
        }

        public void PrintDetails()
        {
            Console.WriteLine($"ID: {MemberID}, Name: {Name}, Email: {Email}");
        }

        public void BorrowBook(Book book)
        {
            Console.WriteLine($"{Name} borrowed {book.Title}");
        }

        public void ReturnBook(Book book)
        {
            Console.WriteLine($"{Name} returned {book.Title}");
        }
    }
    public class PremiumMember : Member
    {
        public DateTime MembershipExpiry { get; set; }
        public int MaxBooksAllowed { get; set; }
        public PremiumMember(string memberID, string name, string email, DateTime expiry, int maxBooks)
       : base(memberID, name, email)
        {
            MembershipExpiry = expiry;
            MaxBooksAllowed = maxBooks;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Expiry: {MembershipExpiry}, Max Books Allowed: {MaxBooksAllowed}");
        }
    }
}

