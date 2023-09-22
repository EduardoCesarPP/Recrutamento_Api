﻿namespace RecrutamentoApi.Modelo
{
    public class ExperienciaProfissional
    {
        public int Id { get; set; }
        public virtual Curriculo Curriculo { get; set; }
        public int CurriculoId { get; set; }
        public string Titulo { get; set; }
        public string TipoEmprego { get; set; }
        public string NomeEmpresa { get; set; }
        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }
    }
}
