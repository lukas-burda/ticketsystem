﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketAnotacaoRepository
    {
        TicketAnotacao Create(TicketAnotacao anotacao);
        TicketAnotacao Update(TicketAnotacao ticketAnotacao);
        TicketAnotacao Delete(int id);
        TicketAnotacao GetById(int id);
    }
}
