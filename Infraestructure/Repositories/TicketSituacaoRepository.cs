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
    public class TicketSituacaoRepository : ITicketSituacaoRepository
    {
        private readonly string _connectionString;

        public TicketSituacaoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("HavanLabs");
        }

        public TicketSituacao Create(TicketSituacao situacao)
        {
            using var connection = new SqlConnection(_connectionString);

            connection.Open();
            var sqlQuery = $"INSERT INTO TicketSituacao (Id,Nome) VALUES ('{situacao.Id}','{situacao.Nome}')";

            int rowsAffected = connection.Execute(sqlQuery, situacao);
            connection.Close();

            return situacao;
        }

        public TicketSituacao Delete()
        {
            throw new NotImplementedException();
        }

        public TicketSituacao GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public TicketSituacao Update()
        {
            throw new NotImplementedException();
        }
    }
}
