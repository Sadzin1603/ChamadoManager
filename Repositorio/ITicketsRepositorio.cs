using Gerenciador_de_chamados.Models;

namespace Gerenciador_de_chamados.Repositorio
{
    public interface ITicketsRepositorio
    {
        
        TicketModel Adicionar(TicketModel ticket);
        List<TicketModel> BuscarTodos();
        List<TicketModel> BuscarTodosCliente(int clienteId);
        List<TicketModel> BuscarTodosFuncionario(int funcionarioId);
        void Atualizar(TicketModel ticket);
        TicketModel FindById(int id);
    }
}
