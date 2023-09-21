using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class NivelFormacaoExtensions
    {
        private static Dictionary<string, NivelFormacao> mapa = new Dictionary<string, NivelFormacao>
        {
            { "FUNDAMENTAL", NivelFormacao.FUNDAMENTAL },
            { "MEDIO", NivelFormacao.MEDIO },
            { "INTELECTGRADUACAOUAL", NivelFormacao.GRADUACAO },
            { "POS_GRADUACAO", NivelFormacao.POS_GRADUACAO },
            { "MESTRADO", NivelFormacao.MESTRADO },
            { "DOUTORADO", NivelFormacao.DOUTORADO },
            { "PHD", NivelFormacao.PHD }
        };

        public static string ParaString(this NivelFormacao valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static NivelFormacao ParaNivelFormacao(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
