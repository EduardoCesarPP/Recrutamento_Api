using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class GeneroExtensions
    {
        private static Dictionary<string, Genero> mapa = new Dictionary<string, Genero>
        {
            { "Masculino", Genero.MASCULINO },
            { "Feminino", Genero.FEMININO },
            { "Transgênero", Genero.TRANSGENERO },
            { "Não Binário", Genero.NAO_BINARIO },
            { "Outro", Genero.OUTRO },
            { "Prefiro não informar", Genero.NAO_INFORMAR }
        };

        public static string ParaString(this Genero valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static Genero ParaGenero(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
