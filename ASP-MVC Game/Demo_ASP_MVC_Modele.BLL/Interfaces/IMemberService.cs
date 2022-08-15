using Demo_ASP_MVC_Modele.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Interfaces
{
    
    public interface IMemberService
    {
        MemberModel Register(MemberModel member);

      
        MemberModel Login(string pseudo, string password); 
    }
}
