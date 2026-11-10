namespace ProjetoLire.Dominio.Entidades
{
    public class PlanoLeitura
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public DateOnly DataInicio { get; set; }
        public int PaginasPorDia { get; set; }
        public DateOnly DataPrevisaoTermino { get; set; }

        public PlanoLeitura()
        {
            TimeSpan tempoDiario = Usuario.TempoDiarioPraLer.ToTimeSpan();

            TimeSpan paginasPorDia = tempoDiario / 5; 

            PaginasPorDia = (int)paginasPorDia.TotalDays;

            var paginasSemana = Usuario.DiasDisponiveisParaLer * paginasPorDia; // 

            var paginasPorSemana = (int)paginasSemana.TotalDays;

            var quantidadeSemanasLeitura = Livro.QuantidadeDePaginas / paginasPorSemana;
            
            DataPrevisaoTermino = DataInicio.AddDays(quantidadeSemanasLeitura * 7);
        }
    }
}