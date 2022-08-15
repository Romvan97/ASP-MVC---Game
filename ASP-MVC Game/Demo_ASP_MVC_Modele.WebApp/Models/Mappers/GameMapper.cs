using Demo_ASP_MVC_Modele.BLL.Entities;

namespace Demo_ASP_MVC_Modele.WebApp.Models.Mappers
{
    public static class GameMapper
    {
        // BLL -> ViewModel
        public static IEnumerable<Game> ToViewModel(this IEnumerable<GameModel> datas)
        {
            foreach (GameModel data in datas)
            {
                yield return data.ToViewModel();
            }

            //return datas.Select(d => d.ToViewModel());
        }

        // BLL -> ViewModel
        public static Game ToViewModel(this GameModel data)
        {
            return new Game
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                Age = data.Age,
                NbPlayerMin = data.NbPlayerMin,
                NbPlayerMax = data.NbPlayerMax,
                IsCoop = data.IsCoop
            };
        }

        // Form -> BLL
        public static GameModel ToModel(this GameForm form)
        {
            return new GameModel()
            {
                Name = form.Name,
                Description = form.Description,
                NbPlayerMin = (int)form.NbPlayerMin,
                NbPlayerMax = (int)form.NbPlayerMax,
                Age = form.Age,
                IsCoop = form.IsCoop
            };
        }
    }
}
