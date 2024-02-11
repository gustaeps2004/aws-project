using AutoMapper;
using AwsProject.Application.DTOs.cad;
using AwsProject.Domain.Models.cad;

namespace AwsProject.Application.Mapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<Collaborator, CollaboratorDto>().ReverseMap();
        }
    }
}
