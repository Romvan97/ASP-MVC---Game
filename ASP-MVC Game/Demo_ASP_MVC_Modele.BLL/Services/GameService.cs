using Demo_ASP_MVC_Modele.BLL.Entities;
using Demo_ASP_MVC_Modele.BLL.Interfaces;
using Demo_ASP_MVC_Modele.BLL.Tools;
using Demo_ASP_MVC_Modele.DAL.Interfaces;
using Demo_ASP_MVC_Modele.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Services
{

    
    public class GameService : IGameService
    {

        private IGameRepository _repo;
     
        public GameService(IGameRepository repo)
        {
           
            _repo = repo;
        }

        public bool AddFavoriteGame(int memberId, int gameId)
        {
            return _repo.AddFavoriteGame(memberId, gameId);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public IEnumerable<GameModel> GetAll()
        {
            return _repo.GetAll().Select(x => x.ToBll()); 
        }

        public GameModel GetById(int id)
        {
            return _repo.GetById(id).ToBll(); 
        }

        public IEnumerable<GameModel> GetByMemberId(int id)
        {
            return _repo.GetByMemberId(id).Select(x => x.ToBll());
        }

        public int Insert(GameModel entity)
        {
            return _repo.Insert(entity.ToDAL());
        }

        public bool Update(GameModel entity)
        {
            return _repo.Update(entity.ToDAL());

        }

    }
}
