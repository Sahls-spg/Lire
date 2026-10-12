using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Dominio.Entidades
{
    public class LivroBiblioteca
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Livro Livro { get; set; }
        public int LivroId { get; set; }
        public StatusLeitura StatusLeitura { get; set; }
        public DateOnly DataAdicionado { get; set; }
    }
}