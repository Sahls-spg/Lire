using System.Net.Http.Json;
using ProjetoLire.Services.DTOs;
using ProjetoLire.Services.Interfaces;

namespace ProjetoLire.Services
{
    public class GoogleBooksService : IGoogleBooksService
    {
        private readonly HttpClient _httpClient;
        public GoogleBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<GoogleLivroRequisicao>> BuscarLivrosAsync(string titulo, string autor)
        {

            if(string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("É necessário informar o título do livro que deseja obter.");
            }

            if(string.IsNullOrWhiteSpace(autor))
            {
                throw new Exception("É necessário informar o(a) autor(a) do livro que deseja obter.");
            }

            string pesquisa = "";

            if (!string.IsNullOrWhiteSpace(titulo))
            {
               pesquisa = $"intitle:{titulo}"; 
            }
            if (!string.IsNullOrWhiteSpace(autor))
            {
                pesquisa += $"+inauthor:{autor}";
            }

            string url =$"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(pesquisa)}&maxResults=1&key=";

            var resposta = await _httpClient.GetFromJsonAsync<GoogleBooksResposta>(url);
            return resposta?.Items ?? new List<GoogleLivroRequisicao>();
        }
    }
}