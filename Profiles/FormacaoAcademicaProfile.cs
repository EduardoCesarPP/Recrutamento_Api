using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class FormacaoAcademicaProfile : Profile
    {
        public FormacaoAcademicaProfile()
        {
            CreateMap<CreateFormacaoAcademicaDto, FormacaoAcademica>();
            CreateMap<FormacaoAcademica, ReadFormacaoAcademicaDto>();
        }

    }
}
