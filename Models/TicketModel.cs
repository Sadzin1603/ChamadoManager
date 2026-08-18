 using Gerenciador_de_chamados.Enums;

namespace Gerenciador_de_chamados.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }

        public TicketStatus Status { get; set; }

        public int ClientId { get; set; }
        public UserModel Client { get; set; }
        
        public int? AssignedEmployeeId { get; set; }
        public UserModel? AssignedEmployee { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ClosedAt { get; set; }

        public ICollection<CommentModel> Comment { get; set; } = new List<CommentModel>();
        public ICollection<TicketHistory> History { get; set; } = new List<TicketHistory>();
    }
}
