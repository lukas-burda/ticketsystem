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
        public Usuario UsuarioAbertura { get; set; }
        public Usuario UsuarioConclusao { get; set; }
        public Cliente Cliente { get; set; }
        public TicketSituacao Situacao { get; set; }
        public int Codigo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
