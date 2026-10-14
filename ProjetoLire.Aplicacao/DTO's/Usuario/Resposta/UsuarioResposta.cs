using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.DTO
{
    public class UsuarioResposta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Genero Genero { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateOnly DataNascimento { get; set; }
        public DateOnly DataCriacaoDaConta { get; set; }
        public List<GeneroLiterario> GenerosLiterariosFavorito { get; set; }
        public List<LivroBiblioteca> LivrosBiblioteca { get; set; }
        public List<PlanoLeitura> PlanosLeitura { get; set; }
        public List<Leitura> Leituras { get; set; }
    }
}