using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Demo_ASP_MVC_Modele.DAL.Interfaces;

namespace Demo_ASP_MVC_Modele.DAL.Entities
{
    public class MemberEntity : IEntity<int>
    {
        public int Id { get; set; }

        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string PwdHash { get; set; }
    }
}
