using AutoMapper;
using Libros.Application.Dtos.Genero;
using Libros.Entitties;

namespace Libros.WebApi.Mapping
{
    public class GeneroMappingProfile : Profile
    {
        public GeneroMappingProfile()
        {
            CreateMap<Genero, GeneroResponseDto>();
            CreateMap<GeneroRequestDto, Genero>();
        }
    }
}
