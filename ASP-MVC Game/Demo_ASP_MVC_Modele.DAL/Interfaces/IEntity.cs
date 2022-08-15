using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.DAL.Interfaces
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
