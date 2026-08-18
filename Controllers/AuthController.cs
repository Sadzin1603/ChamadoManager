using Gerenciador_de_chamados.Models;
using Gerenciador_de_chamados.Repositorio;
using Gerenciador_de_chamados.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador_de_chamados.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuariosRepositorio _userRepositorio;
        public AuthController(IUsuariosRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;   
        }

        [AllowAnonymous]
        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        //POST
        [HttpPost("/login")]
        public IActionResult Login(UserModel user)
        {
            var foundUser = _userRepositorio.FindByEmail(user.Email);
            if (foundUser == null)
            {
                return RedirectToAction("Login");//não achou o email
            }
            //achou o usuraio
            //senha certa?
            if (BCrypt.Net.BCrypt.EnhancedVerify(user.Password, foundUser.Password))
            {
                var token = new TokenServices().Generate(foundUser);
                //armazenar o token em um cookie seguro
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(2)
                });

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");//senha errada
        }

        [HttpPost("/register")] //Cadastro
        public IActionResult Register(UserModel user)
        { 
            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);
            _userRepositorio.Adicionar(user);
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Index","Home");
        }
    }
}
