namespace Gerenciador_de_chamados.Models
{
    public class TicketHistory
    {
        public TicketHistory(string Alteracao,string Autor,DateTime Data)
        {
            this.Alteracao = Alteracao;
            this.Autor = Autor;
            this.Data = Data;
        }
        public int Id { get; set; }
        public string Alteracao { get; set; }
        public string Autor { get; set; }
        public DateTime Data {  get; set;  }
    }
}

