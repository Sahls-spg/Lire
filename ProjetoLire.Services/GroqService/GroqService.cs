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

                1. A idade do usuário e a adequação temática das obras.
                2. Seus gêneros literários favoritos e seus interesses.
                3. Sua experiência com a leitura, considerando a quantidade
                de livros que já leu.
                4. Seu tempo disponível e sua rotina de leitura.
                5. A diversidade de autores, estilos e literaturas brasileiras
                e internacionais.

                Critérios para as recomendações:

                - Priorize livros que realmente combinem com o perfil do leitor.
                - Não se limite aos títulos mais tradicionais ou populares.
                - Explore obras menos conhecidas, autores contemporâneos,
                narrativas diferentes e livros que possam proporcionar
                novas experiências de leitura.
                - Considere obras brasileiras e internacionais.
                - Busque diversidade entre as três recomendações, evitando
                livros muito semelhantes.
                - Não escolha livros apenas por sua popularidade.
                - Não invente títulos ou autores.
                - Priorize obras reais, com informações bibliográficas
                consistentes.
                - Retorne livros somente em português e livros que tenham edição em português
                - Antes de trazer a resposta, valide se os títulos gerados são realmente de livros do contrário refaça a análise.

                O objetivo é proporcionar recomendações personalizadas,
                capazes de ampliar o repertório literário
                do usuário, respeitando seus gostos e sua realidade de leitura.


                Retorne exclusivamente um JSON válido, contendo somente três recomendações.

                Cada recomendação deve possuir somente os campos `titulo` e `autor`.

                Não inclua explicações, comentários, introduções, formatação Markdown ou qualquer texto fora do JSON.
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
