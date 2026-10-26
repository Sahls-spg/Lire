using System.Text.Json.Serialization;

namespace ProjetoLire.Dominio.Enumeradores
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GeneroLiterario
    {
        Romance,
        Fantasia,
        Suspense,
        Terror,
        Misterio,
        Aventura,
        Ficção,
        Religioso,
        Biografia,
        Autoajuda,
        Nenhum
    }
}