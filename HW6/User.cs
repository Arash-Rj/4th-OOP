

using System.Xml.Linq;

namespace HW6
{
    public class User : ILibraryService
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public RoleEnum Role;
        public string Username { get; set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string phonenumber { get; set; }
        public int  Userid { get; set; }
        public int Managerid { get; set; }
        public List<Book> Books { get; set; } = new List<Book>(10);
        public User (string name, string lastname, string email, string password)
        {
            Lastname = lastname;
            Name = name;
            Password = password;
            Username = name + lastname;
            Email = email;
            Userid = Convert.ToInt32(name[0]) * Convert.ToInt32(lastname[1]);
            
        }
        public User()
        { }
        public void Setemail(string email)
        {
            Email = email;
        }
        public void Setpass(string pass)
        {
            Password = pass;
        }
        public void CompleteInfo(string Fname,string Lname,string phoneNumber)
        {
            Name = Fname; 
            Lastname = Lname;
            Username = Fname + Lname;
            Userid = Convert.ToInt32(Fname[0]) * Convert.ToInt32(Lname[1]);
            phonenumber = phoneNumber;
        }
        public void BarrowBook(int Booknumber)
        {
            DateTime date = DateTime.Now;
            foreach (Book book in LibraryStorage.Books)
            {
                if (book.Bookid == Booknumber)
                {
                    book.Barrowdate = date;
                    Books.Add(book);
                    LibraryStorage.Books.Remove(book);
                    break;
                }
            }
        }

        public void RetrunBook(int x)
        {
           foreach(Book book in Books)
            {
                if(book.Bookid == x)
                {
                    AddBookToLibrary(book);
                    RemoveBook(book, Books);
                    break;
                }
            }
        
        }

        public void GetListOfLibraryBooks(List<Book> books)
        {
            int i =1;
            Console.WriteLine("====Library books====");
            foreach (Book book in books)
            {
                if (book == null) { break; }
                //Console.WriteLine(i);
                book.BookInfo();
                i++;
            }

        }

        public void GetListOfUserBooks(List<Book> books)
        {
            int i = 1;
            Console.WriteLine("====books====");
            foreach (Book book in books)
            {
                if (book == null) { break; }
                //Console.WriteLine(i);
                book.BookInfo();
                Console.WriteLine($"Barrow date: {book.Barrowdate}");
                i++;
            }
        }
        public  void RemoveBook(Book book, List<Book> books)
        {
            books.Remove(book);
        }
        public void AddBookToLibrary(Book book1)
        {
          LibraryStorage.Books.Add(book1);
        }
    }
}
