using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCv.Application.CQRS.Command;
using MyCv.Application.CQRS.Queries;
using MyCv.Domain.Entities;
using Nest;
using System.Text.Json;

namespace MyCv.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class ClientController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientCommand command)
        {
            await _mediator.Send(command);
            return Ok("Aday Oluşturuldu");
        }

        [HttpGet]
        public async Task<IActionResult> GetClient()
        {
            var getResponse = await _mediator.Send(new GetClientQuery());
            return Ok(getResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientByIdAsync(Guid id)
        {
            var query= new GetClientByIdQuery(id);
            var results=await _mediator.Send(query);
            return Ok(results);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(DeleteClientCommand command)
        {
            await _mediator.Send(command);
            return Ok("Aday Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(UpdateClientCommand command)
        {
            await _mediator.Send(command);
            return Ok("Aday Güncellendi.");
        }
    }
}
