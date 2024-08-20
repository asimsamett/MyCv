using MyCv.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.CQRS.Results
{
    public class GetClientFutureByIdResult
    {
        public Positions Position { get; set; }
        public Education Education { get; set; }
        public string Referance { get; set; }
    }
}
