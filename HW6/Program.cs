
using HW6;
using System;

UserService userService = new UserService();


int option = 0;
do
{
    Console.Clear();
    Console.WriteLine("**************************");
    Console.WriteLine("Welcome to the library.");
    Console.WriteLine("1.Log in.");
    Console.WriteLine("2.Sign up.");
    Console.WriteLine("3.Exit.");
    Console.WriteLine("**************************");

    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("**************************");
            Console.Write("Please Enter your Email : ");
            string email = Console.ReadLine();
            Console.Write("Please Enter your Password : ");
            string password = Console.ReadLine();
            User U = userService.Login(email, password);
            if (U == null)
            {
                Console.WriteLine("User not found!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("$==================$");
                Console.WriteLine($"Welcome to the library {U.Role} {U.Name}");
                Console.WriteLine("1.Library menu     2.Librarian menu");
                int op1 = int.Parse(Console.ReadLine());
                switch (op1)
                {
                    case 1:
                        libraryMenu(U);
                        break;
                    case 2:
                        if (U.Role == RoleEnum.Manager)
                        {
                            Librarianmeu(U);
                        }
                        else
                        {
                            Console.WriteLine("!!!!You dont have the permission to access the menu.!!!!");
                        }
                        break;
                }


            }
            Console.ReadKey();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("**************************");
            Console.Write("Pls Enter The Email: ");
            string mail = Console.ReadLine();
            Console.Write("Pls Enter The Password: ");
            string Pass = Console.ReadLine();
            Console.WriteLine("Please choose your role: ");
            Console.WriteLine("1.Manager    2.Member");
            int op = int.Parse(Console.ReadLine());
            RoleEnum role = RoleEnum.member;
            switch (op)
            {
                case 1:
                    role = RoleEnum.Manager;
                    break;
                case 2:
                    role = RoleEnum.member;
                    break;
            }
            userService.register(mail, Pass, role);
            break;
    }
}
while (option < 3);
void libraryMenu(User user)
{
    int option2 = 0;
    do
    {
        Console.Clear();
        Console.WriteLine("1.Barrow a book.");
        Console.WriteLine("2.return a book.");
        Console.WriteLine("3.Barrowed books list.");
        Console.WriteLine("4.Library books.");
        Console.WriteLine("5.Exit.");
        option2 = Convert.ToInt32(Console.ReadLine());
        switch (option2)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Whic genre?");
                Console.Write(" Genre: 1.Sports 2.Scientific 3.Cultural ");
                int op5 = Convert.ToInt32(Console.ReadLine());
                GenreEnum genreEnum = (GenreEnum)op5;
                Console.WriteLine("Which Book do you want to barrow?(Book id)");
                foreach (Book book in LibraryStorage.Books)
                {

                    if (book.Genre == genreEnum)
                    {
                        book.BookInfo();
                    }
                }

                //user.GetListOfLibraryBooks(LibraryStorage.Books);
                int op3 = Convert.ToInt32(Console.ReadLine());
                user.BarrowBook(op3);
                //Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                if (user.Books.Count == 0)
                {
                    Console.WriteLine("****You dont have any books yet****");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Wich book do you want to return?");
                    user.GetListOfUserBooks(user.Books);
                    int op4 = Convert.ToInt32(Console.ReadLine());
                    user.RetrunBook(op4);
                }
                break;
            case 3:
                Console.Clear();
                if (user.Books.Count == 0)
                {
                    Console.WriteLine("You dont have any books yet.");
                }
                else
                {
                    user.GetListOfUserBooks(user.Books);
                }
                Console.ReadKey();
                break;
            case 4:
                Console.Clear();
                user.GetListOfLibraryBooks(LibraryStorage.Books);
                Console.ReadKey();
                break;


        }
    }
    while (option2 < 5);
}
void Librarianmeu(User user)
{
    int option3 = 0;
    do
    {
        Console.Clear();
        Console.WriteLine("1.Add a book.");
        Console.WriteLine("2.Search");
        Console.WriteLine("3.Remove a book");
        Console.WriteLine("4.Library books");
        Console.WriteLine("5.Barrowed books");
        Console.WriteLine("6.Log out");
        option3 = Convert.ToInt32(Console.ReadLine());
        switch (option3)
        {
            case 1:
                Console.Clear();
                Console.Write(" Genre: 1.Sports 2.Scientific 3.Cultural ");
                int op3 = Convert.ToInt32(Console.ReadLine());
                GenreEnum genreEnum = (GenreEnum)op3;
                Console.Write("Title: ");
                string title = Console.ReadLine();
                Console.Write("Author: ");
                string author = Console.ReadLine();
                LibraryStorage.Books.Add(new Book(genreEnum, title, author) { Bookid = userService.SearchId(LibraryStorage.Books) });
                Console.WriteLine("-----Book succesfully added-----");
                Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                Console.Write("Search by title of the book: ");
                string T = Console.ReadLine();
                userService.SearchBook(T);
                Console.ReadKey();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Enter the book id you want to remove: ");
                user.GetListOfLibraryBooks(LibraryStorage.Books);
                int id = Convert.ToInt32(Console.ReadLine());
                bool ch = false;
                foreach (Book book in LibraryStorage.Books)
                {
                    if (book.Bookid == id)
                    {
                        LibraryStorage.Books.Remove(book);
                        ch = true;
                        break;
                    }
                }
                if (ch == false)
                { Console.WriteLine("Not found."); }
                break;
            case 4:
                Console.Clear();
                user.GetListOfLibraryBooks(LibraryStorage.Books);
                Console.ReadKey();
                break;
            case 5:
                Console.Clear();
                Console.WriteLine("------Barrowed Books------");
                Manager L = (Manager)user;
                L.BarrowedBooks();
                Console.ReadKey();
                break;
        }
    }
    while (option3 < 6);
}

