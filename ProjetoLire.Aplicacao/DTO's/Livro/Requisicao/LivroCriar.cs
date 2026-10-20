using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.DTO
{
    public class LivroCriar
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public GeneroLiterario GeneroLiterario { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public string Sinopse { get; set; }
    }
}