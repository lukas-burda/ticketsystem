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

namespace Infraestructure.Repositories
{
    public class TicketAnotacaoRepository : ITicketAnotacaoRepository
    {
        private readonly string _connectionString;

        public TicketAnotacaoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("HavanLabs");
        }

        public TicketAnotacao Create(TicketAnotacao anotacao)
        {
            using var connection = new SqlConnection(_connectionString);

            var rules = new Rules();
            var anotacaoQuery = rules.FillFieldsToCreate(anotacao);

            connection.Open();
            var sqlQuery = $"INSERT INTO TicketAnotacao VALUES ({anotacaoQuery.Id}, {anotacaoQuery.TicketId},{anotacaoQuery.IdUsuario},'{anotacaoQuery.Texto}','{anotacaoQuery.Data}') ";

            int rowsAffected = connection.Execute(sqlQuery);
            connection.Close();;
            return anotacao;
        }

        public TicketAnotacao Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TicketAnotacao GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TicketAnotacao Update(TicketAnotacao ticketAnotacao)
        {
            throw new NotImplementedException();
        }
    }
}
