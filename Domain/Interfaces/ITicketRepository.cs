using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketRepository
    {
        Ticket Create(Ticket ticket);
        Ticket Update(Ticket ticket);
        Ticket Delete(Ticket ticket);
        Ticket Get(int id);
    }
}
