using Gerenciador_de_chamados.Data;
using Gerenciador_de_chamados.Models;

namespace Gerenciador_de_chamados.Repositorio
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuariosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UserModel Adicionar(UserModel user) 
        {
            //gravar no banco de dados
            _bancoContext.Users.Add(user);
            _bancoContext.SaveChanges();
            return user;
        }

        public UserModel FindByEmail(string email)
        {
            return _bancoContext.Users.Where(u => u.Email == email).FirstOrDefault();
        }
        public List<UserModel> FindFuncionarios()
        {
            return _bancoContext.Users.Where(u => u.Role == Enums.UserRoles.Funcionario).ToList();   
        }

    }
}
