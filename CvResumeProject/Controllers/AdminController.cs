using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCv.Application.CQRS.AdminCQ.AdminCreate;
using MyCv.Application.CQRS.AdminCQ.AdminDelete;
using MyCv.Application.CQRS.AdminCQ.AdminQueries;
using MyCv.Application.CQRS.AdminCQ.AdminUpdate;

namespace MyCv.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AdminController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublisher _publisher;
        


        public AdminController(IMediator mediator, IPublisher publisher)
        {
            _mediator = mediator;
            _publisher = publisher;

        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminCommand createAdminCommand)
        {
            await _mediator.Send(createAdminCommand);
            
            return Ok("Admin oluşturuldu.");
        }
        [HttpGet]
        public async Task<IActionResult>GetAdmin(Guid id)
        {
            var query = new GetAdminByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminCommand updateAdminCommand)
        {
            await _mediator.Send(updateAdminCommand);
            return Ok("Admin bilgileri güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult>DeleteAdmin(DeleteAdminCommand deleteAdminCommand)
        {
            await _mediator.Send(deleteAdminCommand);
            return Ok("Admin bilgileri silindi.");
        }
    }

}
