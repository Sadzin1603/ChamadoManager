using Gerenciador_de_chamados.Models;

namespace Gerenciador_de_chamados.Repositorio
{
    public interface IUsuariosRepositorio
    {
        UserModel Adicionar(UserModel user);
        UserModel FindByEmail(string email);
        List<UserModel> FindFuncionarios();
    }
}
