using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        readonly IUsuarioRepository _repository;
        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult PostUser()
        {

            var create = _repository.Create(new Usuario
            {
                Id = 1,
                Name = "Teste",
                Codigo = "20"
            });

            return Ok();
        }
    }
}
