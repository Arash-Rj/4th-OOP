using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class Manager : User
    {
        
        public Manager(string name, string lastname, string email, string password) : base(name, lastname, email, password)
        {
            Managerid = Convert.ToInt32(email[0]) + Convert.ToInt32(email[4]);
            Role = RoleEnum.Manager;
        }
        public Manager() { Role = RoleEnum.Manager; }
       public void Setmanagerid(string Email)
        {
            Managerid = Convert.ToInt32(Email[0]) + Convert.ToInt32(Email[0]);
        }
        public void BarrowedBooks()
        {
            foreach(var user in LibraryStorage.Users)
            {
                Console.WriteLine("*****************");
                Console.WriteLine(user.Name);
                user.GetListOfUserBooks(user.Books);
            }
        }
    }
}
