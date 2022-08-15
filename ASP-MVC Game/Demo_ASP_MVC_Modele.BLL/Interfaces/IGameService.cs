using Demo_ASP_MVC_Modele.BLL.Entities;
using Demo_ASP_MVC_Modele.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Interfaces
{
    
   
    public interface IGameService : IRepository<int, GameModel>
    {
        IEnumerable<GameModel> GetByMemberId(int id);
        bool AddFavoriteGame(int memberId, int gameId);
    }
}
