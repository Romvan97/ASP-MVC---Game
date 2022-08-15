using Demo_ASP_MVC_Modele.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.DAL.Interfaces
{
    public interface IMemberRepository : IRepository<int, MemberEntity>
    {
        string GetHashByPseudo(string pseudo);
        MemberEntity GetByPseudo(string pseudo);
        bool CheckUserExists(string email, string pseudo);
    }
}
