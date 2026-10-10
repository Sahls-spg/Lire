namespace ProjetoLire.Dominio.Entidades
{
    public class Leitura
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int LivroId { get; set; }
        public Livro Livro { get; set; }
        public int PaginaAtual { get; set; }
        public DateOnly DataRegistro { get; set; }
    }
}