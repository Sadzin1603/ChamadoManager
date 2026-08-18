using Gerenciador_de_chamados.Enums;
using Gerenciador_de_chamados.Models;
using Gerenciador_de_chamados.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Gerenciador_de_chamados.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketsRepositorio _ticketsRepositorio;
        public HomeController(ITicketsRepositorio ticketsRepositorio)
        {
            _ticketsRepositorio = ticketsRepositorio;
        }
        public IActionResult Index()
        {
            string? jwt = Request.Cookies["jwt"];

            if (jwt != null)
            {
                var handler = new JwtSecurityTokenHandler();

                var jwtSecurityToken = handler.ReadJwtToken(jwt);

                UserModel user = new UserModel();
                user.Name = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
                user.Role = (UserRoles)int.Parse(jwtSecurityToken.Claims.First(c => c.Type == "role").Value);
                user.Id = int.Parse(jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value);

                if (user.Role == UserRoles.Cliente)
                {
                    List<TicketModel> tickets = _ticketsRepositorio.BuscarTodosCliente(user.Id);
                    return View(Tuple.Create(user, tickets));
                }
                else if (user.Role == UserRoles.Funcionario)
                {
                    List<TicketModel> tickets = _ticketsRepositorio.BuscarTodosFuncionario(user.Id);
                    return View(Tuple.Create(user, tickets));
                }

                return View(Tuple.Create(user, new List<TicketModel>() ));
            }
           return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
