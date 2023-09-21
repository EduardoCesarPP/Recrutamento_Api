using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class ModalidadeExtensions
    {
        private static Dictionary<string, Modalidade> mapa = new Dictionary<string, Modalidade>
        {
            { "HOME_OFFICE", Modalidade.HOME_OFFICE },
            { "HIBRIDO", Modalidade.HIBRIDO },
            { "PRESENCIAL", Modalidade.PRESENCIAL }
        };

        public static string ParaString(this Modalidade valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static Modalidade ParaModalidade(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
