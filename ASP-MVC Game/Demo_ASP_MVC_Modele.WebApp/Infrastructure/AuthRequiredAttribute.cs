using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo_ASP_MVC_Modele.WebApp.Infrastructure
{
    
    public class AuthRequiredAttribute : TypeFilterAttribute 
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter)) { }
    }

    public class AuthRequiredFilter : IAuthorizationFilter
    {
        private SessionManager session;

        public AuthRequiredFilter(SessionManager session)
        {
            this.session = session;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(session.CurrentUser is null)
            {
               
                context.Result = new RedirectToRouteResult(new { action = "Login", controller = "Member" });
            }
        }
    }
}
