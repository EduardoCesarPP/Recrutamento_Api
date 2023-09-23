using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class StatusInscricaoExtensions
    {
        private static Dictionary<string, StatusInscricao> mapa = new Dictionary<string, StatusInscricao>
        {
            { "ENVIO CURRICULO", StatusInscricao.ENVIO_CURRICULO },
            { "TESTE DISSERTACAO", StatusInscricao.TESTE_DISSERTACAO },
            { "ANALISE CURRICULO", StatusInscricao.ANALISE_CURRICULO },
            { "ENTREVISTA RH", StatusInscricao.ENTREVISTA_RH },
            { "ENTREVISTA GESTOR", StatusInscricao.ENTREVISTA_GESTOR },
            { "FINALIZADA", StatusInscricao.FINALIZADA }
        };

        public static string ParaString(this StatusInscricao valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static StatusInscricao ParaStatusInscricao(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
