using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Demo_ASP_MVC_Modele.WebApp.Models
{
    public class Game
    {
        [ScaffoldColumn(false)] // évite d'ajouter l'id dans la vue lors du scaffold (génération auto de la vue)
        public int Id { get; set; }

        [DisplayName("Nom du jeu")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Joueur Minimum")]
        public int NbPlayerMin { get; set; }

        [DisplayName("Joueur Maximum")]
        public int NbPlayerMax { get; set; }

        [DisplayName("Age Recommendé")]
        public int? Age { get; set; }

        [DisplayName("Cooperatif")]
        public bool IsCoop { get; set; }
    }

    public class GameForm
    {
        [DisplayName("Nom du jeu")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Nombre de joueur Minimum")]
        [Required]
        [Range(1, int.MaxValue)]
        public int? NbPlayerMin { get; set; }

        [DisplayName("Nombre de joueur Maximum")]
        [Required]
        [Range(1, int.MaxValue)]
        public int? NbPlayerMax { get; set; }

        [DisplayName("Age Recommendé")]
        [Range(0, 150)]
        public int? Age { get; set; }

        [DisplayName("Jeu cooperatif")]
        [Required]
        public bool IsCoop { get; set; }
    }

    public class FavoriteForm
    {
        public IEnumerable<Game> GameList { get; set; }
        public int SelectedId { get; set; }
    }
}
