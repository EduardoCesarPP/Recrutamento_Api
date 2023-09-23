using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class RacaExtensions
    {
        private static Dictionary<string, Raca> mapa = new Dictionary<string, Raca>
        {
            { "Branca(o)", Raca.BRANCO },
            { "Preta(o) ou Negra(o)", Raca.PRETO },
            { "Árabe ou Oriente Médio", Raca.ARABE },
            { "Indígena ou Nativa(o)", Raca.INDIGENA },
            { "Parda(o)", Raca.PARDO },
            { "Prefiro não informar", Raca.NAO_INFORMAR },
            { "Amarela(o) ou Asiática(o)", Raca.ASIATICO }
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
