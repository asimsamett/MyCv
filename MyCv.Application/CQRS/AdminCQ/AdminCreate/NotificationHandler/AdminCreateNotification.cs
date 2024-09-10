using MediatR;
using MyCv.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.CQRS.AdminCQ.AdminCreate.NotificationHandler
{
    public class AdminCreateNotification:INotification
    {
        public Admin admin { get; set; }

        public AdminCreateNotification(Admin admin)
        {
            this.admin = admin;
        }
    }
}
