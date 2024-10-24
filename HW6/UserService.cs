using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class UserService : IAuthentication
    {
        public User? Login(string email, string password)
        {
            {
                foreach (User user in LibraryStorage.Users)
                {
                    if (user == null) { break; }
                    if (user.Email == email && user.Password == password)
                    {
                        return user;
                    }

                }
                return null;
            }
        }

        public void register(string email, string password, RoleEnum role)
        {

            bool check = Duplicatedemailorpass(email, password);
            if (check == false && role == RoleEnum.member)
            {
                member m1 = new member();
                m1.Setemail(email);
                m1.Setpass(password);
                LibraryStorage.Users.Add(m1);
                Console.WriteLine("Register Successful");
                Console.ReadKey();
            }
            else if (check == false && role == RoleEnum.Manager)
            {
                Manager ma = new Manager();
                ma.Setemail(email);
                ma.Setpass(password);
                ma.Setmanagerid(email);
                LibraryStorage.Users.Add(ma);
                Console.WriteLine("Register Successful");
                Console.ReadKey();
            }



        }
        public bool Duplicatedemailorpass(string email, string password)
        {
            for (int i = 0; i < LibraryStorage.Users.Count; i++)
            {
                if (LibraryStorage.Users[i] != null)
                {
                    if (LibraryStorage.Users[i].Email == email)
                    {
                        Console.WriteLine("The email  Already exists");
                        Console.ReadKey();
                        return true;
                    }
                    else if (LibraryStorage.Users[i].Password == password)
                    {
                        Console.WriteLine("The password alrerady exists.");
                        Console.ReadKey();
                        return true;
                    }
                }
            }
            return false;
        }
        public void SearchBook(string title)
        {
            bool check = false;
            int i = 1;
            foreach (var item in LibraryStorage.Books)
            {
                if (item.Title.SearchInString(title) == true)
                {
                    Console.WriteLine(i + ".");
                    item.BookInfo();
                    //Console.WriteLine("---------------")
                    check = true;
                }
            }
            if (check == false)
            {
                Console.WriteLine("No books found!");
            }
        }
        public int SearchId(List<Book> books)
        {
            int c =books.Count;
            c++;
            return c;   
        }
    }
}
