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
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public Usuario Create(Usuario usuario)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var query = "INSERT INTO USUARIO VALUES (@Id, @Codigo, @Cpf)";

            Console.WriteLine(query);
            return usuario;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
