using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class RacaExtensions
    {
        private static Dictionary<string, Raca> mapa = new Dictionary<string, Raca>
        {
            { "BRANCO", Raca.BRANCO },
            { "PRETO", Raca.PRETO },
            { "ARABE", Raca.ARABE },
            { "INDIGENA", Raca.INDIGENA },
            { "PARDO", Raca.PARDO },
            { "NAO_INFORMAR", Raca.NAO_INFORMAR },
            { "ASIATICO", Raca.ASIATICO }
        };

        public static string ParaString(this Raca valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static Raca ParaRaca(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
