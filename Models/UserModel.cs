using Gerenciador_de_chamados.Enums;

namespace Gerenciador_de_chamados.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public UserRoles Role { get; set; }

    }
}
