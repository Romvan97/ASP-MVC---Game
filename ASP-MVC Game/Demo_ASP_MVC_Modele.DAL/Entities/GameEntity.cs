using Demo_ASP_MVC_Modele.DAL.Interfaces;

namespace Demo_ASP_MVC_Modele.DAL.Entities
{
    public class GameEntity : IEntity<int>
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
