using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
    }
}
