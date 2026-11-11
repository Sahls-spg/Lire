namespace ProjetoLire.Aplicacao.DTO
{
    public class PlanoLeituraResposta
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateOnly DataInicio { get; set; }
        public int PaginasPorDia { get; set; }
        public DateOnly DataPrevisaoTermino { get; set; }
    }
}