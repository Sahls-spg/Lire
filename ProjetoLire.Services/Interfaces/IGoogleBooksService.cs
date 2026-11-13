using ProjetoLire.Services.DTOs;

namespace ProjetoLire.Services.Interfaces
{
    public interface IGoogleBooksService
    {
        Task<List<GoogleLivroRequisicao>> BuscarLivrosAsync(string titulo, string autor);
    }
}