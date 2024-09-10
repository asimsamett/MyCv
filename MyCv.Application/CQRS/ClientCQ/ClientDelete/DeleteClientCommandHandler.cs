using MediatR;
using MyCv.Application.Interfaces.IRepository;

namespace MyCv.Application.CQRS.ClientCQ.ClientDelete
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IWriteRepository _clientRepository;

        public DeleteClientCommandHandler(IWriteRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Handle(DeleteClientCommand command, CancellationToken cancellationToken)
        {
            await _clientRepository.DeleteAsync(command.Id);
        }
    }
}
