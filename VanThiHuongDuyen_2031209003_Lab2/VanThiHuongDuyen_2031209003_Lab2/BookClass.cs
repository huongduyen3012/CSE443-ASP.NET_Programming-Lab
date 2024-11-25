using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    class BookClass
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public BookClass(string iSBN, string title, string author)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
        }


    }
    record BookRecord(string ISBN, string Title, string Author);
}
