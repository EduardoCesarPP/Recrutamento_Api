using AutoMapper;
using RecrutamentoApi.Dados.Dtos;
using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CreateEmpresaDto, Empresa>();

            CreateMap<UpdateEmpresaDto, Empresa>();

            CreateMap<Empresa, ReadEmpresaDto>()
                .ForMember(candidatoDto => candidatoDto.Endereco, opt => opt.MapFrom(candidato => candidato.Endereco));

        }
    }
}
