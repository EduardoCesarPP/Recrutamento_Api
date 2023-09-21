using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class CandidatoProfile : Profile
    {
        public CandidatoProfile()
        {
            CreateMap<CreateCandidatoDto, Candidato>()
                .ForMember(candidato => candidato.Deficiencias, opt => opt.MapFrom(candidatoDto => candidatoDto.Deficiencias));

            CreateMap<Candidato, ReadCandidatoDto>()
                .ForMember(candidatoDto => candidatoDto.Endereco, opt => opt.MapFrom(candidato => candidato.Endereco));

        }

    }
}
