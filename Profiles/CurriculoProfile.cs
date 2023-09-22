using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class CurriculoProfile : Profile
    {
        public CurriculoProfile()
        {
            CreateMap<CreateCurriculoDto, Curriculo>()
                .ForMember(curriculo => curriculo.DeficienciaFisica, opt => opt.MapFrom(curriculoDto => curriculoDto.Deficiencias.Fisica))
                .ForMember(curriculo => curriculo.DeficienciaAuditiva, opt => opt.MapFrom(curriculoDto => curriculoDto.Deficiencias.Auditiva))
                .ForMember(curriculo => curriculo.DeficienciaVisual, opt => opt.MapFrom(curriculoDto => curriculoDto.Deficiencias.Visual))
                .ForMember(curriculo => curriculo.DeficienciaAutista, opt => opt.MapFrom(curriculoDto => curriculoDto.Deficiencias.Autista))
                .ForMember(curriculo => curriculo.DeficienciaIntelectual, opt => opt.MapFrom(curriculoDto => curriculoDto.Deficiencias.Intelectual));

            CreateMap<Curriculo, ReadCurriculoDto>()
                .ForMember(curriculoDto => curriculoDto.Endereco, opt => opt.MapFrom(curriculo => curriculo.Endereco))
                .ForPath(
                    curriculoDto => curriculoDto.Deficiencias.Fisica,
                    path => path.MapFrom(curriculo => curriculo.DeficienciaFisica))
                .ForPath(
                    curriculoDto => curriculoDto.Deficiencias.Auditiva,
                    path => path.MapFrom(curriculo => curriculo.DeficienciaAuditiva))
                .ForPath(
                    curriculoDto => curriculoDto.Deficiencias.Visual,
                    path => path.MapFrom(curriculo => curriculo.DeficienciaVisual))
                .ForPath(
                    curriculoDto => curriculoDto.Deficiencias.Autista,
                    path => path.MapFrom(curriculo => curriculo.DeficienciaAutista))
                .ForPath(
                    curriculoDto => curriculoDto.Deficiencias.Intelectual,
                    path => path.MapFrom(curriculo => curriculo.DeficienciaIntelectual));

        }

    }
}
