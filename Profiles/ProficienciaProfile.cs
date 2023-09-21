using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class ProficienciaProfile : Profile
    {
        public ProficienciaProfile()
        {
            CreateMap<CreateProficienciaDto, Proficiencia>();
            CreateMap<Proficiencia, ReadProficienciaDto>();
        }

    }
}
