using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    interface ILibraryService
    {
        void BarrowBook(int booknumber);
        void RetrunBook(int number);
        void GetListOfLibraryBooks(List<Book> books);
        void GetListOfUserBooks(List<Book> books);
    }
}
