using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITicketRepository _ticketRepository;

        public TicketController(
            ILogger<WeatherForecastController> logger, 
            ITicketRepository ticketRepository)
        {
            _logger = logger;
            _ticketRepository = ticketRepository;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Ticket ticket)
        {
            try
            {
                return Created($"Criado com o id {ticket.Id}", _ticketRepository.Create(ticket));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
