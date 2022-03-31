using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int IdUsuarioAbertura { get; set; }
        public int IdUsuarioConclusao { get; set; }
        public int IdCliente { get; set; }
        public int IdTicketSituacao { get; set; }
        public int Codigo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
