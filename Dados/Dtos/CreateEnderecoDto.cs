﻿namespace RecrutamentoApi.Dados.Dtos
{
    public class CreateEnderecoDto
    {
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
