using MyCv.Application.CQRS.ClientCQ.ClientCreate;
using MyCv.Application.CQRS.ClientCQ.ClientDelete;
using MyCv.Application.CQRS.ClientCQ.ClientUpdate;
using MyCv.Application.Interfaces.IElasticSearchRepostory;
using MyCv.Domain.Entities.Client;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Infrastructure.Repositories.ElasticSearchRepostory
{
    public class WriteElasticSearchRepostory : IWriteElasticSearchRepostory
    {
        private readonly IElasticClient _client;
        private const string indexname = "client";
        public WriteElasticSearchRepostory(IElasticClient client)
        {
            _client = client;
        }
        public async Task<CreateClientCommand> CreateAsync(CreateClientCommand client)
        {
            var response= await _client.IndexAsync(client, x=>x.Index(indexname).Id(Guid.NewGuid().ToString()));
            if (!response.IsValid)
            {
                return null;
            }
            client.Id = Guid.Parse(response.Id);
            return client;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response=await _client.DeleteAsync<DeleteClientCommand>(id,x=>x.Index(indexname));
            return response.IsValid;
            
        }

        public async Task<bool> UpdateAsync(UpdateClientCommand client)
        {
            var response=await _client.UpdateAsync<UpdateClientCommand>(client, x=>x.Index(indexname).Doc(client)); 
            return response.IsValid;
        }
    }
}
