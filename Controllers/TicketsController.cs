using Gerenciador_de_chamados.Models;
using Gerenciador_de_chamados.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gerenciador_de_chamados.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsRepositorio _ticketRepositorio;
        private readonly IUsuariosRepositorio _usuariosRepositorio;
        public TicketsController (ITicketsRepositorio ticketsRepositorio,IUsuariosRepositorio usuariosRepositorio)
        {
            _ticketRepositorio = ticketsRepositorio;
            _usuariosRepositorio = usuariosRepositorio;
        }
        [Authorize]
        [Route("chamado/{id}")]
        public IActionResult Index(int id)
        {
            TicketModel ticket = _ticketRepositorio.FindById(id);
            return View(ticket);
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            List<TicketModel> tickets = _ticketRepositorio.BuscarTodos();
            List<UserModel> funcionarios = _usuariosRepositorio.FindFuncionarios();
            return View(Tuple.Create(tickets,funcionarios));
        }

        [HttpPost]
        public IActionResult Criar(TicketModel ticket)
        {
            ticket.CreatedAt = DateTime.Now;
            //ticket.History.Add(new TicketHistory("Ticket Criado","Fulano",DateTime.Now));
            _ticketRepositorio.Adicionar(ticket);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AlterarFuncionario(int ticketId, int userId)
        {
            TicketModel ticket = _ticketRepositorio.FindById(ticketId);
            ticket.AssignedEmployeeId = userId;
            _ticketRepositorio.Atualizar(ticket);
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        public IActionResult AdicionarComentario(int ticketId, string content)
        {
            //obter o usuario logado
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            _ticketRepositorio.FindById(ticketId).Comment.Add(new CommentModel
            {
                UserId = userId,
                Content = content,
                CreatedAt = DateTime.Now
            });
            _ticketRepositorio.Atualizar(_ticketRepositorio.FindById(ticketId));

            return RedirectToAction("Index", new { id = ticketId });
        }

        [HttpPost]
        public IActionResult AlterarStatus(int ticketId,int status)
        {
            TicketModel ticket = _ticketRepositorio.FindById(ticketId);
            ticket.Status = (Enums.TicketStatus)status; 
            _ticketRepositorio.Atualizar(ticket);
            return RedirectToAction("Index", new { id = ticketId });
        }

    }
}
