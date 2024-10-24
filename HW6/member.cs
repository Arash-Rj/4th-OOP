using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class member : User
    {
        public member(string name, string lastname, string email, string password) : base(name, lastname, email, password)
        {
            Role = RoleEnum.member;
        }
        public member() { Role = RoleEnum.member; }
       

       
    }
}
