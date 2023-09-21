namespace RecrutamentoApi.Modelo
{
    public class Idioma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Proficiencia> Proficiencias { get; set; }
        public Idioma()
        {
            Proficiencias = new List<Proficiencia>(); 
        }
    }
}
