using Demo_ASP_MVC_Modele.BLL.Entities;
using Demo_ASP_MVC_Modele.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Tools
{
   
    public static class Mappers
    {
        public static GameModel ToBll(this GameEntity game)
        {
            return new GameModel
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Age = game.Age,
                IsCoop = game.IsCoop,
                NbPlayerMax = game.NbPlayerMax,
                NbPlayerMin = game.NbPlayerMin
            };
        }

        public static GameEntity ToDAL(this GameModel game)
        {
            return new GameEntity
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Age = game.Age,
                IsCoop = game.IsCoop,
                NbPlayerMax = game.NbPlayerMax,
                NbPlayerMin = game.NbPlayerMin
            };
        }



        public static MemberModel ToBll(this MemberEntity member)
        {
            return new MemberModel
            {
                Id = member.Id,
                Email = member.Email,
                Pseudo = member.Pseudo,
                Pwd = null
            };
        }

        // La dal ne vérifie rien elle enregistre juste, ici on met null pour eviter que le mot de passe en claire soit enregistré
        public static MemberEntity ToDAL(this MemberModel member)
        {
            return new MemberEntity
            {
                Id = member.Id,
                Email = member.Email,
                Pseudo = member.Pseudo,
                PwdHash = null
            };
        }
    }
}
