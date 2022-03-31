using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketAnotacaoRepository _ticketAnotacaoRepository;

        public TicketController(
            ITicketRepository ticketRepository,
            ITicketAnotacaoRepository ticketAnotacaoRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketAnotacaoRepository = ticketAnotacaoRepository;
        }

        [HttpPost("/criar")]
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

        [HttpPost("/anotar")]
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

        [HttpPost("/concluir")]
        public IActionResult Concluir([FromQuery]int codigoTicket)
        {
            try
            {
                var ticket = _ticketRepository.Concluir(codigoTicket);
                return Ok($"O Ticket {codigoTicket} foi concluído com sucesso.");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/visualizar")]
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
