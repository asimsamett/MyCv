using MediatR;
using MyCv.Application.Interfaces.IRepository;
using MyCv.Domain.Entities.Client;
using Nest;


namespace MyCv.Application.CQRS.ClientCQ.ClientCreate
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand>
    {
        private readonly IWriteRepository _clientRepository;
        private readonly IElasticClient _elasticClient;


        public CreateClientCommandHandler(IWriteRepository clientRepository, IElasticClient elasticClient)
        {
            _clientRepository = clientRepository;
            _elasticClient = elasticClient;
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
                    command.Email,
                    new ClientFeatures
                        (
                            command.ClientFeature.Position,
                            command.ClientFeature.Education,
                            command.ClientFeature.Referance
                        )
                );


            await _clientRepository.AddAsync(client);
            await _clientRepository.SaveChangeAsync();

            
            

        }
    }
}
