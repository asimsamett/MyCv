using MediatR;
using MyCv.Application.Interfaces.IRepository;
using MyCv.Domain.Entities;
using MyCv.Domain.Entities.Client;

namespace MyCv.Application.CQRS.ClientCQ.ClientUpdate
{

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IReadRepository _readClientRepository;
        private readonly IWriteRepository _writeClientRepository;

        public UpdateClientCommandHandler(IReadRepository clientRepository, IWriteRepository writeClientRepository)
        {
            _readClientRepository = clientRepository;
            _writeClientRepository = writeClientRepository;
        }

        public async Task Handle(UpdateClientCommand command, CancellationToken cancellationToken)
        {

            var client = await _readClientRepository.GettByIdAsync(command.ClientId);
            client.ClientProperties(
                command.Name,
                command.Surname,
                command.PhoneNumber,
                command.Address,
                command.Email,
                new ClientFeatures
                (
                    command.UpdateClientFeatures.Position,
                    command.UpdateClientFeatures.Education,
                    command.UpdateClientFeatures.Referance
                )
            );
            await _writeClientRepository.UpdateAsync(client);
            await _writeClientRepository.SaveChangeAsync();

        }
    }
}
