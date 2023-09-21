using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class IdiomaProfile : Profile
    {
        public IdiomaProfile()
        {
            CreateMap<CreateIdiomaDto, Idioma>();
            CreateMap<Idioma, ReadIdiomaDto>();
        }

    }
}
