using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public static class LibraryStorage
    {
        public static List<Book> Books { get; set; } = new List<Book>();
        public static List<User> Users { get; set; } = new List<User>();
        static LibraryStorage()
        {
            Books.Add(new(GenreEnum.Sceintific, "Earth and space", "B") { Bookid=1});
            Books.Add(new(GenreEnum.Cultural, "Earn respect", "D") { Bookid=2});
            Books.Add(new(GenreEnum.Sports, "Football near you", "F") { Bookid=3});
            Users.Add(new member("Arash", "Rajabi", "rajabiarash36@gmail.com", "12345"));
            Users.Add(new member("Ali", "Niazi", "AliN32@gmail.com", "213243"));
            Users.Add(new Manager("Kasra", "Kavosi", "KasraK21@gmail.com", "56789"));
        }
    }
}
