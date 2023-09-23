using RecrutamentoApi.Modelo;

namespace RecrutamentoApi.Extensions
{
    public static class NivelProficienciaExtensions
    {
        private static Dictionary<string, NivelProficiencia> mapa = new Dictionary<string, NivelProficiencia>
        {
            { "Básico", NivelProficiencia.BASICO },
            { "Intermediário", NivelProficiencia.INTERMEDIARIO },
            { "Avançado", NivelProficiencia.AVANCADO }
        };

        public static string ParaString(this NivelProficiencia valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static NivelProficiencia ParaNivelProficiencia(this string texto)
        {
            return mapa.First(c => c.Key == texto).Value;
        }
    }
}
