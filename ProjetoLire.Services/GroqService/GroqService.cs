using System.Text;
using System.Text.Json;
using ProjetoLire.Dominio.Enumeradores;
using ProjetoLire.Services.Interfaces;

namespace ProjetoLire.Services
{
    public class GroqService : IGroqService
    {
        private readonly HttpClient _httpClient;

        public GroqService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        string url = "https://api.groq.com/openai/v1/chat/completions";

        public async Task<string?> RecomendarLivrosAsync(DateOnly dataNascimento, Genero genero, int quantidadeLivrosLidos, List<GeneroLiterario> generosFavoritos, TimeOnly tempoDisponivel, int diasDisponiveis)
        {
            var dataDeHoje = DateOnly.FromDateTime(DateTime.Today);

            int idade = dataDeHoje.Year - dataNascimento.Year;

            if (dataNascimento > dataDeHoje.AddYears(-idade))
            {
                idade--;
            }

            var prompt = $"""
                        Você é um especialista em recomendações literárias personalizadas e hábitos de leitura.
                        Analise cuidadosamente o perfil abaixo antes de selecionar os livros.

                        PERFIL DO LEITOR:
                        Idade: {idade}
                        Quantidade de livros lidos: {quantidadeLivrosLidos}
                        Gêneros favoritos: {string.Join(", ", generosFavoritos)}
                        Tempo diário para leitura: {tempoDisponivel}
                        Dias disponíveis para leitura: {diasDisponiveis}

                        REGRAS PARA GERAR A RECOMENDAÇÃO:

                        1. Priorize os gêneros favoritos do usuário.

                        2. Considere a experiência do leitor:
                        - Se leu menos de 20 livros, prefira leituras acessíveis e com menas páginas.

                        - Se já leu mais de 20 livros, explore obras mais elaboradas e diferentes.

                        3. Considere o tempo disponível para leitura.
                        Prefira livros com tamanho e complexidade
                        compatíveis com a rotina do usuário.

                        4. Não recomende apenas livros famosos.
                        Explore obras menos convencionais e autores contemporâneos.

                        5. Escolha livros diferentes entre si, mas que tenham relação com os interesses do leitor.

                        6. Recomende apenas livros reais que possuam edição publicada em português.

                        7. Não repita títulos na mesma resposta.
                        Não invente livros nem autores.

                        8. Considere primeiro a compatibilidade com o perfil, depois a diversidade das sugestões.

                        Retorne exclusivamente um JSON válido com três livros, contendo somente titulo e autor.

                        Não inclua explicações ou texto fora do JSON.
                    """;

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");

            var payload = new
            {
                model = "openai/gpt-oss-120b",
                messages = new[]
                {
                    new { role = "system", content = prompt },
                }
            };

            string json = JsonSerializer.Serialize(payload);

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");


            HttpResponseMessage resposta = await _httpClient.PostAsync(url, conteudo);

            string resultado = await resposta.Content.ReadAsStringAsync();

            if (!resposta.IsSuccessStatusCode)
            {
                throw new Exception($"Erro na Groq: {resposta.StatusCode} - {resultado}");
            }

            using (JsonDocument doc = JsonDocument.Parse(resultado))
            {
                var raiz = doc.RootElement;

                var mensagem = raiz.GetProperty("choices")[0]
                                   .GetProperty("message")
                                   .GetProperty("content")
                                   .GetString();

                return mensagem;
            }
        }
    }
}
