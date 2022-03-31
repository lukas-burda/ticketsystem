using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketSituacaoRepository
    {
        TicketSituacao Create(TicketSituacao ticket);
        TicketSituacao Update(TicketSituacao ticket);
        TicketSituacao Delete();
        TicketSituacao GetById(int Id);
    }
}
