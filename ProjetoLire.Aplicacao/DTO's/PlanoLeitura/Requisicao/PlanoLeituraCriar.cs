namespace ProjetoLire.Aplicacao.DTO
{
    public class PlanoLeituraCriar
    {
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateOnly DataInicio { get; set; }
        public TimeOnly TempoDiarioPraLer { get; set; }
        public int DiasDisponiveisParaLer { get; set; }
        public int PaginasPorDia { get; set; }
        public DateOnly DataPrevisaoTermino { get; set; }
    }
}