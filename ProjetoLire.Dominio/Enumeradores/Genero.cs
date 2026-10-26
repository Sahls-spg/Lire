using System.Text.Json.Serialization;

namespace ProjetoLire.Dominio.Enumeradores
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Genero
    {
        Masculino,
        Feminino
    }
}