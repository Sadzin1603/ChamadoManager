using Gerenciador_de_chamados.Data;
using Gerenciador_de_chamados.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_chamados.Repositorio
{
    public class TicketsRepositorio : ITicketsRepositorio
    {
        private readonly BancoContext _ticketsRepositorio;
        public TicketsRepositorio(BancoContext bancoContext)
        {
            _ticketsRepositorio = bancoContext;
        }
        public TicketModel Adicionar(TicketModel ticket)
        {
            _ticketsRepositorio.Tickets.Add(ticket);
            _ticketsRepositorio.SaveChanges();
            return ticket;
        }

        public void Atualizar(TicketModel ticket)
        {
            _ticketsRepositorio.Tickets.Update(ticket);
            _ticketsRepositorio.SaveChanges();
        }

        public List<TicketModel> BuscarTodos()
        {
            return _ticketsRepositorio.Tickets.ToList();
        }

        public List<TicketModel> BuscarTodosCliente(int clienteId)
        {
            return _ticketsRepositorio.Tickets.Where(t => t.ClientId == clienteId).ToList();
        }

        public List<TicketModel> BuscarTodosFuncionario(int funcionarioId)
        {
            return _ticketsRepositorio.Tickets.Where(t => t.AssignedEmployeeId == funcionarioId).ToList();
        }

        public TicketModel FindById(int id)
        {
            return _ticketsRepositorio.Tickets
                .Include(t => t.Comment)
                .Include(c => c.Client)
                .FirstOrDefault(t => t.Id == id);
        }
    }
}
