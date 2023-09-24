﻿using RecrutamentoApi.Modelo;

using Newtonsoft.Json;
using RecrutamentoApi.Dados.Dtos.Interfaces;

namespace RecrutamentoApi.Dados.Dtos
{
    public class ReadCertificacaoDto : IReadDto
    {
        public string Titulo { get; set; }
        public string Organizacao { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DataEmissao { get; set; }
    }
}
