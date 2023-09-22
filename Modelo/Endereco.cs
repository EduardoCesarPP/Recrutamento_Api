namespace RecrutamentoApi.Modelo
{
    public class Endereco
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual List<Empresa> Empresas { get; set; }
        public virtual List<Curriculo> Curriculos { get; set; }
    }
}