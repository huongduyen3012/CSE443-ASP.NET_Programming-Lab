using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    interface IPrintable
    {
        void PrintDetails()
        {

        }



    }
    public interface IMemberActions
    {
        void BorrowBook(Book book);
        void ReturnBook(Book book);
    }
}
