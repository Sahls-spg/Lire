using System.Text;
using System.Text.Json;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Dominio.Enumeradores;

namespace ProjetoLire.Services
{
    public class GroqService : IGroqService
    {
        private readonly HttpClient _httpClient;
        
        string url = "https://api.groq.com/openai/v1/chat/completions";
        
        public async Task<string?> RecomendarLivrosAsync(DateOnly dataNascimento, Genero genero, int quantidadeLivrosLidos, List<GeneroLiterario> generosFavoritos, TimeOnly tempoDisponivel, int diasDisponiveis)
        {
            int idade = DateTime.Today.Year - dataNascimento.Year;

            var prompt = $""" 
                'Você é um especialista em análise de perfis de leitura e recomendações literárias. 
                Que possui amplo conhecimento sobre livros, autores e obras da literatura brasileira e internacional, abrangendo diferentes gêneros literários e estilos de escrita.
                Sua tarefa é analisar cuidadosamente as informações de leitura do usuário apresentadas abaixo e recomendar somente três livros que tenham maior compatibilidade com seu perfil.

                Idade: {idade}
                Gênero: {genero}
                Quantidade de livros já lidos: {quantidadeLivrosLidos}
                Gêneros literários favoritos: {generosFavoritos}
                Tempo disponível diariamente para leitura: {tempoDisponivel}
                Quantidade de dias disponíveis para leitura: {diasDisponiveis}

                Ao analisar o perfil, considere:
                1. Os gêneros literários favoritos do usuário.
                2. A quantidade de livros que ele já leu, considerando seu nível de familiaridade com a leitura.
                3. O tempo diário e a quantidade de dias disponíveis para ler.
                4. Sua idade e genero
                5. A diversidade de autores, estilos e literaturas brasileiras e internacionais.

                Priorize livros que tenham maior possibilidade de agradar ao usuário, considerando suas preferências e sua realidade de leitura.

                Não escolha livros apenas por sua popularidade. Procure identificar obras que realmente combinem com o perfil apresentado.

                Se tiver acesso à pesquisa na internet, utilize informações confiáveis para conhecer melhor as obras e verificar sua relevância. Não invente títulos, autores ou informações bibliográficas.

                Retorne exclusivamente um JSON válido, contendo somente três recomendações.

                Cada recomendação deve possuir somente os campos `titulo` e `autor`.

                Não inclua explicações, comentários, introduções, formatação Markdown ou qualquer texto fora do JSON.
                """;

            

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer ");

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