using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Rules
    {
        public Ticket FillFieldsToCreate(Ticket ticket, ITicketSituacaoRepository repo, List<Ticket> tickets)
        {
            foreach (var item in tickets)
            {
                if (item.IdCliente == ticket.IdCliente)
                {
                    return null;
                }
            }

            var situacao = repo.Create(new TicketSituacao { Id = new Random().Next(32767), Nome = "Em atendimento" });

            ticket.Id = new Random().Next();
            ticket.IdSituacao = situacao.Id;
            ticket.DataAbertura = DateTime.UtcNow;

            return ticket;
        }

        public TicketAnotacao FillFieldsToCreate(TicketAnotacao anotacao)
        {
            anotacao.Id = new Random().Next();
            anotacao.Data = DateTime.UtcNow;
            return anotacao;
        }

        public Ticket FillFieldsToConclude(Ticket ticket, ITicketSituacaoRepository repo)
        {
            TicketSituacao situacao = repo.GetById(ticket.IdSituacao);
            situacao.Nome = "Concluído";
            repo.Update(situacao);

            ticket.IdUsuarioConclusao = ticket.IdUsuarioAbertura;
            ticket.DataConclusao = DateTime.UtcNow;

            return ticket;
        }
    }
}
