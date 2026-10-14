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
        public TimeOnly TempoDiarioPraLer { get; set; }
        public int DiasDisponiveisParaLer { get; set; }
        public int PaginasPorDia { get; set; }
        public DateOnly DataPrevisaoTermino { get; set; }

        public PlanoLeitura()
        {
            TimeSpan tempoDiario = TempoDiarioPraLer.ToTimeSpan();

            TimeSpan paginasPorDia = tempoDiario / 5; // 6 pag

            PaginasPorDia = (int)paginasPorDia.TotalDays;

            var paginasSemana = DiasDisponiveisParaLer * paginasPorDia; // 

            var paginasPorSemana = (int)paginasSemana.TotalDays;

            var quantidadeSemanasLeitura = Livro.QuantidadeDePaginas / paginasPorSemana;
            
            DataPrevisaoTermino = DataInicio.AddDays(quantidadeSemanasLeitura * 7);
        }
    }
}