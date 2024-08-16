using Nest;
using Elasticsearch;
using MyCv.Application.Interfaces;
using MyCv.Domain.Entities;
using System.Runtime.InteropServices;

namespace MyCv.Infrastructure.Repositories
{
    public class ElasticSearchRepository : IClientElasticSearch
    {
        private readonly IElasticClient _elasticClient;
        public ElasticSearchRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<List<Client>> GetClientByIdAsync(Guid id)
        {
            var response = await _elasticClient.SearchAsync<Client>(s => s
                .Query(q => q
                    .MatchAll() 
        ));


            return response.Documents.ToList();
        }

        public async Task CreateClientAsync(Client client)
        {
            var response = await _elasticClient.IndexDocumentAsync(client);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var response = await _elasticClient.DeleteAsync<Client>(id.ToString());
        }



        public async Task<Client> UpdateClientAsync(Client client)
        {
            var response = await _elasticClient.UpdateAsync<Client>(client.Id.ToString(), x => x.Doc(client));
            return client;
        }
        public Task SaveChangeAsync()
        {

            /* Chat Gpt' den öğrendiğim yöntem, Şuan için
            tek Entity FrameWork ORM yapısı bulunuyor
            ve gerekli olmayan bir kod. */

            return Task.CompletedTask;
        }

    }
}
