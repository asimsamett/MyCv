using MyCv.Application.CQRS.ClientCQ.ClientQueries;
using MyCv.Domain.Entities.Client;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.Interfaces.IElasticSearchRepostory
{
    public interface IReadElasticSearchRepostory
    {
        Task<ImmutableList<GetClientResult>> GetAllAsync();
        Task<GetClientByIdResult> GetByIdAsync(Guid id);
    }
}
