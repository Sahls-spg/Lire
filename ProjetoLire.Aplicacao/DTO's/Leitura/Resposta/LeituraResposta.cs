namespace ProjetoLire.Aplicacao.DTO
{
    public class LeituraResposta
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public int PaginaAtual { get; set; }
        public DateOnly DataRegistro { get; set; }
    }
}