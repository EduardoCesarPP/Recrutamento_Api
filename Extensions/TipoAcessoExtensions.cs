using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class TipoAcessoExtensions
    {
        private static Dictionary<string, TipoAcesso> mapa = new Dictionary<string, TipoAcesso>
        {
            { "EMPRESA", TipoAcesso.EMPRESA },
            { "CANDIDATO", TipoAcesso.CANDIDATO },
            { "ADMNINISTRACAO", TipoAcesso.ADMNINISTRACAO }
        };

        public static string ParaString(this TipoAcesso valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static TipoAcesso ParaTipoAcesso(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
