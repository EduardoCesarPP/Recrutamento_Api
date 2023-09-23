using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class TipoVagaExtensions
    {
        private static Dictionary<string, TipoVaga> mapa = new Dictionary<string, TipoVaga>
        {
            { "CLT", TipoVaga.CLT },
            { "PJ", TipoVaga.PJ },
            { "Estágio", TipoVaga.ESTAGIO },
            { "Aprendiz", TipoVaga.APRENDIZ }
        };

        public static string ParaString(this TipoVaga valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static TipoVaga ParaTipoVaga(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
