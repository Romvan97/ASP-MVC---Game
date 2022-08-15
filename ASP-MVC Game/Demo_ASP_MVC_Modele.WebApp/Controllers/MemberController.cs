using Demo_ASP_MVC_Modele.BLL.Interfaces;
using Demo_ASP_MVC_Modele.WebApp.Infrastructure;
using Demo_ASP_MVC_Modele.WebApp.Models;
using Demo_ASP_MVC_Modele.WebApp.Models.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP_MVC_Modele.WebApp.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _service;
        private SessionManager _session;
        private IGameService _gameService;

        public MemberController(IMemberService service, SessionManager session, IGameService gameService)
        {
            _service = service;
            _session = session;
            _gameService = gameService;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register([FromForm] MemberRegForm form)
        {
            if (!ModelState.IsValid) return View(form);
            try
            {
                //todo autoconnect
                _service.Register(form.ToBll());
                return RedirectToAction("Index", "Game");
            }
            catch(Exception e)
            {
                ViewData["error"] = e.Message;
                return View(form);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(MemberLoginForm form)
        {
            if (!ModelState.IsValid) return View(form);

            try
            {
                Member currentUser = _service.Login(form.Pseudo, form.Pwd).ToWeb();

                _session.CurrentUser = currentUser;

                return RedirectToAction("Index", "Game");
            }
            catch(Exception e)
            {
                ViewData["error"] = e.Message;
                return View(form);
            }
            

        }

        public IActionResult Logout()
        {
            _session.Logout();
            return RedirectToAction("Index", "Home");
        }

        [AuthRequired]
        public IActionResult Profil()
        {
            MemberProfilView model = _session.CurrentUser.ToView(_gameService);

            return View(model);
        }

    }
}
