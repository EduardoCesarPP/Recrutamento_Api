using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class NivelFormacaoExtensions
    {
        private static Dictionary<string, NivelFormacao> mapa = new Dictionary<string, NivelFormacao>
        {
            { "Fundamental", NivelFormacao.FUNDAMENTAL },
            { "Ensino Médio", NivelFormacao.MEDIO },
            { "Graduação", NivelFormacao.GRADUACAO },
            { "Pós Graduação", NivelFormacao.POS_GRADUACAO },
            { "Mestrado", NivelFormacao.MESTRADO },
            { "Doutorado", NivelFormacao.DOUTORADO },
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
