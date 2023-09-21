using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class CertificacaoProfile : Profile
    {
        public CertificacaoProfile()
        {
            CreateMap<CreateCertificacaoDto, Certificacao>();
            CreateMap<Certificacao, ReadCertificacaoDto>();
        }

    }
}
