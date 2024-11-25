using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    class LibraryCard
    {
        public string CardNumber { get; private set; }
        public Member Owner { get; set; }
        public DateTime IssueDate { get; private set; }

        public LibraryCard(string cardNumber, Member owner)
        {
            CardNumber = cardNumber;
            Owner = owner;
            IssueDate = DateTime.Now;
        }

        public void RenewCard()
        {
            IssueDate = DateTime.Now;
            Console.WriteLine($"Library card for {Owner.Name} is renewed. New issue date: {IssueDate}");
        }
    }
}
