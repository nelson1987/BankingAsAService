using AutoMapper;
using Baas.Domain.Commands;
using Baas.Domain.Entities;
using Baas.Domain.Repositories.DTOs;

namespace Baas.Api.Filters
{

    public class DtoToCommand : Profile
    {
        public DtoToCommand()
        {
            //CreateMap<AccountDTO, InsertAccountCommand>();
            //CreateMap<AccountDTO, AberturaContaCommand>();
            CreateMap<AberturaContaCommand, AccountDTO>()
            .ForMember(x => x.Id, y => y.Ignore())
            .ForMember(x => x.Numero, y => y.Ignore());
            CreateMap<AccountDTO, ContaAbertaEvent>();
            CreateMap<AccountDTO, AberturaContaCommandResponse>();
            //CreateMap<AccountDTO, AccountQuery>();

            //            Missing type map configuration or unsupported mapping.

            //Mapping types:
            //AberturaContaCommand->AccountDTO
            //Baas.Domain.Commands.AberturaContaCommand->Baas.Domain.Repositories.DTOs.AccountDTO
        }
    }
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            //CreateMap<Account, InsertAccountResponse>();
        }
    }
}