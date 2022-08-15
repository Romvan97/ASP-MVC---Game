using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Entities
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
    }
}
