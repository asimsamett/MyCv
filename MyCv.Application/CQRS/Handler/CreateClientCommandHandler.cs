using MediatR;
using MyCv.Application.CQRS.Command;
using MyCv.Application.Interfaces;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.Handler
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var client = new Client();
            
            client.ClientProperties
                (
               
                command.Name,
                command.Surname,
                command.PhoneNumber,
                command.Address,
                command.Email
                );
            await _clientRepository.AddAsync(client);
            await _clientRepository.SaveChangeAsync();

        }
    }
}
