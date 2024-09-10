using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.CQRS.AdminCQ.AdminQueries
{
    public class GetAdminByIdQuery : IRequest<GetAdminByIdResult>
    {
        public Guid Id { get; set; }

        public GetAdminByIdQuery(Guid ıd)
        {
            Id = ıd;
        }
    }
}
