using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCv.Application.CQRS.ClientCQ.ClientCreate;
using MyCv.Application.CQRS.ClientCQ.ClientDelete;
using MyCv.Application.CQRS.ClientCQ.ClientQueries;
using MyCv.Application.CQRS.ClientCQ.ClientUpdate;
using MyCv.Application.Interfaces.IElasticSearchRepostory;
using MyCv.Domain.Entities.Client;
using Nest;
using System.Collections.Immutable;

namespace MyCv.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ClientController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IReadElasticSearchRepostory _readElasticSearchRepostory;
        private readonly IWriteElasticSearchRepostory _writeElasticSearchRepostory;

        public ClientController(IMediator mediator, IReadElasticSearchRepostory readElasticSearchRepostory, IWriteElasticSearchRepostory writeElasticSearchRepostory)
        {
            _mediator = mediator;
            _readElasticSearchRepostory = readElasticSearchRepostory;
            _writeElasticSearchRepostory = writeElasticSearchRepostory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientCommand command)
        {
            await _mediator.Send(command);
            await _writeElasticSearchRepostory.CreateAsync(command);
            return Ok("Aday Oluşturuldu");
        }

        [HttpGet]
        public async Task<IActionResult> GetClient()
        {
            //var getResponse = await _mediator.Send(new GetClientQuery());
            var getResponse = await _readElasticSearchRepostory.GetAllAsync();
            if (getResponse.IsEmpty)
            {
                var query = new GetClientQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            } 
            return Ok(getResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientByIdAsync(Guid id)
        {
            
            var results = await _readElasticSearchRepostory.GetByIdAsync(id);
            if (results == null)
            {
                var query = new GetClientByIdQuery(id);
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            return Ok(results);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(DeleteClientCommand command)
        {
            await _mediator.Send(command);
            await _writeElasticSearchRepostory.DeleteAsync(command.Id);
            return Ok("Aday Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(UpdateClientCommand command)
        {
            await _mediator.Send(command);
            await _writeElasticSearchRepostory.UpdateAsync(command);
            return Ok("Aday Güncellendi.");
        }
    }
}
