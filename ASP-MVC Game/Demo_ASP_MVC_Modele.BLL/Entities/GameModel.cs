using Demo_ASP_MVC_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Entities
{
    public class GameModel : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NbPlayerMin { get; set; }
        public int NbPlayerMax { get; set; }
        public int? Age { get; set; }
        public bool IsCoop { get; set; }
    }
}
