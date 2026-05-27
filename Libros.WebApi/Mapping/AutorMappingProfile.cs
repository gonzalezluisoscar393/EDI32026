using AutoMapper;
using Libros.Application.Dtos.Autor;
using Libros.Entitties;

namespace Libros.WebApi.Mapping
{
    public class AutorMappingProfile : Profile
    {
        public AutorMappingProfile()
        {
            CreateMap<Autor, AutorResponseDto>().
                ForMember(dest => dest.FechaNacimiento, ori => ori.MapFrom(src => src.FechaNacimiento.ToShortDateString()));
            CreateMap<AutorRequestDto, Autor>();
        }
    }
}
