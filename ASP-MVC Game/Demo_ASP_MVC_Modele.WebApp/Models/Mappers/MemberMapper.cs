using Demo_ASP_MVC_Modele.BLL.Entities;
using Demo_ASP_MVC_Modele.BLL.Interfaces;

namespace Demo_ASP_MVC_Modele.WebApp.Models.Mappers
{
    public static class MemberMapper
    {
        // Envoie à la bll le modèle
        public static MemberModel ToBll(this MemberRegForm form)
        {
            return new MemberModel
            {
                Email = form.Email,
                Pwd = form.Pwd,
                Pseudo = form.Pseudo
            };
        }

        // Recoit un modèle
        public static Member ToWeb(this MemberModel m)
        {
            return new Member
            {
                Id = m.Id,
                Email = m.Email,
                Pseudo = m.Pseudo
            };
        }

        // Recoit un modèle
        public static MemberProfilView ToView(this Member m, IGameService gameService)
        {
            return new MemberProfilView
            {
                Id = m.Id,
                Email = m.Email,
                Pseudo = m.Pseudo,
                FavoriteList = gameService.GetByMemberId(m.Id).Select(x => x.ToViewModel())
            };
        }
    }
}
