using Demo_ASP_MVC_Modele.WebApp.Models;
using System.Text.Json;

namespace Demo_ASP_MVC_Modele.WebApp.Infrastructure
{
    // Création de la session manager (Elle est placée dans un dossier infrastructure ou tools)
    public class SessionManager
    {
        private ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        //stock le membre, le panier, les favoris pour le garder en mémoire
        public Member CurrentUser
        {
            get
            {
                // Vérifie que l'utilisateur actuel n'est pas null
                if (string.IsNullOrWhiteSpace(_session.GetString("currentUser"))) return null;

                // Ca peut aussi etre un panier,...
                return JsonSerializer.Deserialize<Member>(_session.GetString("currentUser"));
            }

            set
            {
                // Ne peut garder que des strings, et le convertits en objets Json
                _session.SetString("currentUser", JsonSerializer.Serialize(value));
            }
        }

        // Permet de se délog de son compte
        public void Logout()
        {
            CurrentUser = null;
        }


    }
}
