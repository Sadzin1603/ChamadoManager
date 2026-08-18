using Gerenciador_de_chamados.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_chamados.Data
{
    public class BancoContext: DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TicketHistory> TicketsHistory { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

    }
}
