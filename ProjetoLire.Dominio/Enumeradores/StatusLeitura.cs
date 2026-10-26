using System.Text.Json.Serialization;

namespace ProjetoLire.Dominio.Enumeradores
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusLeitura
    {
        QueroLer,
        Lendo,
        Lido,
        Abandonado
    }
}