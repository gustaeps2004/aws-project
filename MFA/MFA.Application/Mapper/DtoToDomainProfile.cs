using AutoMapper;
using MFA.Application.DTOs.cad;
using MFA.Domain.Models.cad;

namespace MFA.Application.Mapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<Collaborator, CollaboratorDto>().ReverseMap();
        }
    }
}
