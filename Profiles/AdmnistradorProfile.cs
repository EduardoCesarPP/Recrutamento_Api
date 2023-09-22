using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class AdmnistradorProfile : Profile
    {
        public AdmnistradorProfile()
        {
            CreateMap<CreateAdmnistradorDto, Admnistrador>();

            CreateMap<Admnistrador, ReadAdmnistradorDto>();

        }

    }
}
