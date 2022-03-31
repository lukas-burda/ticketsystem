using Application;
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

        public int Concluir(int id)
        {
            var rules = new Rules();
            Ticket ticket = rules.FillFieldsToConclude(GetByCode(id), _ticketSituacaoRepository);

            using var connection = new SqlConnection(_connectionString);

            connection.Open();
            var sqlQuery = $"UPDATE Ticket SET IdUsuarioConclusao = {ticket.IdUsuarioConclusao}, DataConclusao = '{ticket.DataConclusao}' WHERE ID = '{ticket.Id}'";
            int rowsAffected = connection.Execute(sqlQuery, sqlQuery);
            connection.Close();
            return rowsAffected;
        }

        public string Create(Ticket ticket)
        {
            var rules = new Rules();
            var ticketQuery = rules.FillFieldsToCreate(ticket, _ticketSituacaoRepository, GetAll());

            if(ticketQuery != null) {
                using var connection = new SqlConnection(_connectionString);

                connection.Open();
                var sqlQuery = $"INSERT INTO Ticket (Id,IdUsuarioAbertura,IdCliente,IdSituacao,DataAbertura) " +
                    $"VALUES ({ticketQuery.Id},{ticketQuery.IdUsuarioAbertura},{ticketQuery.IdCliente},{ticketQuery.IdSituacao},'{ticketQuery.DataAbertura}')";

                int rowsAffected = connection.Execute(sqlQuery, ticketQuery);
                connection.Close();

                Ticket ticketCode = GetById(ticketQuery.Id);

                return $"Ticket {ticketCode.Codigo} criado com sucesso";
             }
            else
            {
                return "Não foi possível criar o ticket pois este cliente já possui um ticket em andamento";
            }
        }

        public Ticket Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket GetById(int Id)
        {
            using var connection = new SqlConnection(_connectionString);

            connection.Open();
            Ticket ticket = connection.Query<Ticket>($"SELECT * FROM Ticket WHERE ID = {Id}").FirstOrDefault();
            connection.Close();

            return ticket;
        }

        public Ticket GetByCode(int Id)
        {
            using var connection = new SqlConnection(_connectionString);

            connection.Open();
            Ticket ticket = connection.Query<Ticket>($"SELECT * FROM Ticket WHERE Codigo = {Id}").FirstOrDefault();
            connection.Close();

            return ticket;
        }

        public List<Ticket> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);

            return connection.Query<Ticket>("SELECT * FROM Ticket").ToList();
        }

        public Ticket Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
