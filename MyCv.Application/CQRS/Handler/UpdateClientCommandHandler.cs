using MediatR;
using MyCv.Application.CQRS.Command;
using MyCv.Application.Interfaces;

namespace MyCv.Application.CQRS.Handler
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GettByIdAsync(command.ClientId);
            client.ClientProperties(
                
                command.Name,
                command.Surname,
                command.PhoneNumber,
                command.Address,
                command.Email
                );
            await _clientRepository.UpdateAsync(client);
            await _clientRepository.SaveChangeAsync();

        }
    }
}
