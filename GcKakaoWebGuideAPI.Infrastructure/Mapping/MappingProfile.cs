using AutoMapper;
using GcKakaoWebGuideAPI.Domain.Entities;
using GcKakaoWebGuideAPI.Infrastructure.Persistence.Models;

namespace GcKakaoWebGuideAPI.Infrastructure.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Heroi, HeroiDocument>().ReverseMap();
        CreateMap<Usuario, UsuarioDocument>().ReverseMap();
    }
}
