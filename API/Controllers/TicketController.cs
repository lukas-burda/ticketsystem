using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketAnotacaoRepository _ticketAnotacaoRepository;

        public TicketController(
            ILogger<WeatherForecastController> logger, 
            ITicketRepository ticketRepository,
            ITicketAnotacaoRepository ticketAnotacaoRepository)
        {
            _logger = logger;
            _ticketRepository = ticketRepository;
            _ticketAnotacaoRepository = ticketAnotacaoRepository;
        }

        [HttpPost]
        [Route("/criar")]
        public IActionResult Criar([FromBody] Ticket ticket)
        {
            try
            {
                
                return Ok($"{_ticketRepository.Create(ticket)}");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/anotar")]
        public IActionResult Anotar([FromBody]TicketAnotacao anotacao)
        {
            try
            {
                _ticketAnotacaoRepository.Create(anotacao);
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/concluir")]
        public IActionResult Concluir([FromQuery]int id)
        {
            try
            {
                var ticket = _ticketRepository.Concluir(id);
                return Ok($"O Ticket {id} foi concluído com sucesso.");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/visualizar")]
        public IActionResult Visualizar([FromQuery]int id)
        {
            try
            {

                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
