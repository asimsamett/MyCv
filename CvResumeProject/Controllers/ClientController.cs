using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCv.Application.CQRS.Command;
using MyCv.Application.CQRS.Queries;
using MyCv.Application.Interfaces;
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
        private readonly IElasticClient _elasticClient;

        public ClientController(IMediator mediator, IElasticClient elasticClient)
        {
            _mediator = mediator;
            _elasticClient = elasticClient;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientCommand command)
        {
            await _mediator.Send(command);
            var indexResponse = JsonSerializer.Serialize(command);    
             IndexResponse? asd = await _elasticClient.IndexDocumentAsync(command.ToString());
            if(asd.IsValid)
                return Ok($"  Aday Oluşturuldu  "+command +$"  ElasticSearch' e Gönderildi=>  "+indexResponse);
            else
                return Ok($"  Aday Oluşturuldu fakat elastic'e atılamadı: " + asd.Result);
        }   

        [HttpGet]
        public async Task<IActionResult> GetClient()
        {
            //var getResponse = await _elasticClient.GetAsync<Client>(id.ToString());

            var getResponse = await _mediator.Send(new GetClientQuery());
            return Ok(getResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetClientByIdAsync(Guid id)
        {
            //var clients = await _elasticClient.GetAsync();
            //return Ok(clients);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(DeleteClientCommand command)
        {
            await _mediator.Send(command);
            var deleteResponse = await _elasticClient.DeleteAsync<Client>(command.Id.ToString());
            return Ok("Aday Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(UpdateClientCommand command)
        {
            //var updateResponse = await _elasticClient.UpdateAsync<Client>(command);

            await _mediator.Send(command);
            return Ok("Aday Güncellendi.");
        }
    }
}
