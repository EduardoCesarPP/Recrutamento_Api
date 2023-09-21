using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class ExperienciaProfissionalProfile : Profile
    {
        public ExperienciaProfissionalProfile()
        {
            CreateMap<CreateExperienciaProfissionalDto, ExperienciaProfissional>();
            CreateMap<ExperienciaProfissional, ReadExperienciaProfissionalDto>();
        }

    }
}
