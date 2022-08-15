using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_MVC_Modele.WebApp.Models
{
    public class Member
    {
        [ScaffoldColumn(false)] // évite d'ajouter l'id dans la vue
        public int Id { get; set; }

        [DisplayName("Email")] // Sert dans les vues à ajouter ce titre lors du scaffold
        public string Email { get; set; }

        [DisplayName("Login")]
        public string Pseudo { get; set; }
    }

    public class MemberRegForm
    {
        [DisplayName("Login")]
        [Required(ErrorMessage = "Votre login est requis")] // Mot de passe requis

        public string Pseudo { get; set; }


        [DisplayName("Email")]
        [Required]

        // Ce champs devra etre de type email (fait les vérificatiosn pour nous)
        [DataType(DataType.EmailAddress, ErrorMessage = "Votre Email est invalide")] 
        public string Email { get; set; }

        [DisplayName("Mot de passe")]
        [Required]
        [DataType(DataType.Password, ErrorMessage = "votre mot de passe est invalide")]
        public string Pwd { get; set; }

        [DisplayName("Confirmation du mot de passe")]
        [Required]
        [DataType(DataType.Password, ErrorMessage = "votre mot de passe est invalide")]
        [Compare(nameof(Pwd), ErrorMessage = "Les mots de passes ne correspondent pas")]
        public string PwdRepeat { get; set; }
    }

    public class MemberLoginForm
    {
        [DisplayName("Login")]
        [Required(ErrorMessage = "Votre login est requis")]

        public string Pseudo { get; set; }

        [DisplayName("Mot de passe")]
        [Required]
        [DataType(DataType.Password, ErrorMessage = "votre mot de passe est invalide")]
        public string Pwd { get; set; }
    }

    // sert à faire Profil utilisateur (profil + liste de ses favoris)
    public class MemberProfilView : Member
    {
        public IEnumerable<Game> FavoriteList { get; set; }
    }
}
