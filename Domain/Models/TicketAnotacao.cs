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
        public Ticket Ticket { get; set; }
        public Usuario Usuario { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
    }
}
