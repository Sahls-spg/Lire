namespace ProjetoLire.Aplicacao.DTO
{
    public class PlanoLeituraAtualizar
    {
        public int LivroId { get; set; }
        public DateOnly DataInicio { get; set; }
        public TimeOnly TempoDiarioPraLer { get; set; }
        public int DiasDisponiveisParaLer { get; set; }
        public int PaginasPorDia { get; set; }
        public DateOnly DataPrevisaoTermino { get; set; }
    }
}