namespace RecrutamentoApi.Modelo
{
    public interface IPessoa : IIdentificado
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
