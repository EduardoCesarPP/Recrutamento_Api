using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class GeneroExtensions
    {
        private static Dictionary<string, Genero> mapa = new Dictionary<string, Genero>
        {
            { "MASCULINO", Genero.MASCULINO },
            { "FEMININO", Genero.FEMININO },
            { "TRANSGENERO", Genero.TRANSGENERO },
            { "NAO_BINARIO", Genero.NAO_BINARIO },
            { "OUTRO", Genero.OUTRO },
            { "NAO_INFORMAR", Genero.NAO_INFORMAR }
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
