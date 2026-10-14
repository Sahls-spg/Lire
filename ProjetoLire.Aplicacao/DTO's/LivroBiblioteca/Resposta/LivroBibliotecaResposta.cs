using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.DTO
{
    public class LivroBibliotecaResposta
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public StatusLeitura StatusLeitura { get; set; }
        public DateOnly DataAdicionado { get; set; }
    }
}