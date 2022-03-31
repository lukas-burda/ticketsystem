using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class TicketRepository : ITicketRepository
    {
        private readonly string _connectionString;
        private readonly ITicketSituacaoRepository _ticketSituacaoRepository;

        public TicketRepository(IConfiguration configuration, ITicketSituacaoRepository ticketSituacaoRepository)
        {
            _connectionString = configuration.GetConnectionString("HavanLabs");
            _ticketSituacaoRepository = ticketSituacaoRepository;
        }
        public Ticket Create(Ticket ticket)
        {
            var situacao = _ticketSituacaoRepository.Create(new TicketSituacao { Id = new Random().Next(32767), Nome = "Aberto" });

            var ticketQuery = new Ticket
            {
                Id = new Random().Next(),
                IdTicketSituacao = situacao.Id,
                Codigo = new Random().Next(),
                DataAbertura = DateTime.Now
            };

            using var connection = new SqlConnection(_connectionString);

            connection.Open();
            var sqlQuery = $"INSERT INTO Ticket (Id,IdUsuarioAbertura,IdCliente,IdSituacao,Codigo,DataAbertura) " +
                $"VALUES ({ticketQuery.Id},{ticketQuery.IdUsuarioAbertura},{ticketQuery.IdCliente},{situacao.Id},{ticketQuery.Codigo},'{ticketQuery.DataAbertura}')";

            int rowsAffected = connection.Execute(sqlQuery, ticketQuery);
            connection.Close();
            return ticket;
        }

        public Ticket Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket Get(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
