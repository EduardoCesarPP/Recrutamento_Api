using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class VagaProfile : Profile
    {
        public VagaProfile()
        {
            CreateMap<CreateVagaDto, Vaga>();

            CreateMap<Vaga, ReadVagaDto>();

        }

    }
}
