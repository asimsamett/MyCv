using MyCv.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.Interfaces.ICacheRepository
{
    public interface IReadCacheRepostory
    {
        Task<Admin> GetByIdAsync<Admin>(Guid id);
    }
}
