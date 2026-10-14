namespace ProjetoLire.Aplicacao.DTO
{
    public class LeituraCriar
    {
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public int PaginaAtual { get; set; }
        public DateOnly DataRegistro { get; set; }
    }
}