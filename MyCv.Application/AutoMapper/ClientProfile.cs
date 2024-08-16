

using AutoMapper;
using MyCv.Application.CQRS.DTO;
using MyCv.Application.CQRS.Results;
using MyCv.Domain.Entities;

namespace MyCv.Application.AutoMapper
{
    public class ClientProfile : Profile
    {

        public ClientProfile()
        {
            //Client Automapper
            CreateMap<Client, GetClientResult>()
                .ForMember(destination => destination.Id, operation => operation.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.Name))
                .ForMember(destination => destination.Surname, operation => operation.MapFrom(source => source.Surname))
                .ForMember(destination => destination.Email, operation => operation.MapFrom(source => source.Email))
                .ForMember(destination => destination.Address, operation => operation.MapFrom(source => source.Address))
                .ForMember(destination => destination.PhoneNumber, operation => operation.MapFrom(source => source.PhoneNumber));

            //ClientFuture Automapper
            CreateMap<ClientFeatures, GetClientFutureResult>()
                .ForMember(destination => destination.Education, operation => operation.MapFrom(source => source.Education))
                .ForMember(destination => destination.Referance, operation => operation.MapFrom(source => source.Referance))
                .ForMember(destination => destination.Position, operation => operation.MapFrom(source => source.Position));
        }
    }
}
