using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class CandidatoProfile : Profile
    {
        public CandidatoProfile()
        {
            CreateMap<CreateCandidatoDto, Candidato>();

            CreateMap<Candidato, ReadCandidatoDto>();

        }

    }
}
