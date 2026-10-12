using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Aplicacao.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Genero Genero { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateOnly DataNascimento { get; set; }
    }
}
