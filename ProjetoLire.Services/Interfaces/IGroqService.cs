using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Services
{
    public interface IGroqService
    {
        Task<string?> RecomendarLivrosAsync(DateOnly dataNascimento, Genero genero, int quantidadeLivrosLidos, List<GeneroLiterario> generosFavoritos, TimeOnly tempoDisponivel, int diasDisponiveis);
    }
}