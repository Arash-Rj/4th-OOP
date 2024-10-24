using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public interface IAuthentication
    {
        public User? Login(string email, string password);

        public  void register(string email, string password, RoleEnum role );
       

    }
}
