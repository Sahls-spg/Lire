using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Dominio.Entidades
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public GeneroLiterario GeneroLiterario { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public string Sinopse { get; set; }
    }
}