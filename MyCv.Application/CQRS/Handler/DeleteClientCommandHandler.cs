using MediatR;
using MyCv.Application.CQRS.Command;
using MyCv.Application.Interfaces;

namespace MyCv.Application.CQRS.Handler
{
    public class DeleteClientCommandHandler:IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Handle(DeleteClientCommand command, CancellationToken cancellationToken)
        {
            await _clientRepository.DeleteAsync(command.Id);
        }
    }
}
