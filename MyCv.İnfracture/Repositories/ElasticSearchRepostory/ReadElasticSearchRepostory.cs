using MyCv.Application.CQRS.ClientCQ.ClientQueries;
using MyCv.Application.Interfaces.IElasticSearchRepostory;
using MyCv.Domain.Entities.Client;
using Nest;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Infrastructure.Repositories.ElasticSearchRepostory
{
    public class ReadElasticSearchRepostory : IReadElasticSearchRepostory
    {
        private readonly IElasticClient _client;
        private const string indexname = "client";
        public ReadElasticSearchRepostory(IElasticClient client)
        {
            _client = client;
        }

        public async Task<ImmutableList<GetClientResult>> GetAllAsync()//ımmutable özelliği veri tutarlılığı sağlamak içindir
        {

            var result = await _client.SearchAsync<GetClientResult>(
                s => s.Index(indexname).Query(q => q.MatchAll()));
            foreach (var hit in result.Hits) hit.Source.Id = Guid.Parse(hit.Id);
            return result.Documents.ToImmutableList();
        }

        public async Task<GetClientByIdResult> GetByIdAsync(Guid id)
        {
            var response = await _client.GetAsync<GetClientByIdResult>
                (
                    id, x => x.Index(indexname)
                );
            response.Source.Id = Guid.Parse(response.Id);
            return response.Source;
        }
    }
}
