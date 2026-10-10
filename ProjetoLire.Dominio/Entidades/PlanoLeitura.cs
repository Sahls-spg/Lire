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
    }
}