using MyCv.Application.CQRS.ClientCQ.ClientCreate;
using MyCv.Application.CQRS.ClientCQ.ClientUpdate;
using MyCv.Domain.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.Interfaces.IElasticSearchRepostory
{
    public interface IWriteElasticSearchRepostory
    {
        Task<CreateClientCommand> CreateAsync(CreateClientCommand client);
        Task<bool> UpdateAsync(UpdateClientCommand client);
        Task<bool> DeleteAsync(Guid id);

    }
}
