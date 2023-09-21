using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class InscricaoProfile : Profile
    {
        public InscricaoProfile()
        {
            CreateMap<CreateInscricaoDto, Inscricao>();
            CreateMap<Inscricao, ReadCandidatoInscricaoDto>();
            CreateMap<Inscricao, ReadVagaInscricaoDto>();
        }

    }
}
