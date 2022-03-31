using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TicketAnotacao
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int IdUsuario { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
    }
}
