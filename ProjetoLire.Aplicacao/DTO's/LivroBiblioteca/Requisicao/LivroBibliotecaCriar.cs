using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.DTO
{
    public class LivroBibliotecaDTO
    {
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public StatusLeitura StatusLeitura { get; set; }
        public DateOnly DataAdicionado { get; set; }
    }
}