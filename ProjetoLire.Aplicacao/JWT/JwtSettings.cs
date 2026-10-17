namespace ProjetoLire.Aplicacao.JWT
{
    public class JwtSettings
    {
        public const string Secao = "JwtSettings";

        public string Chave { get; set; }

        public string Emissor { get; set; } 

        public string Audiencia { get; set; } 

        public int ExpiracaoToken { get; set; }

        public JwtSettings()
        {
            ExpiracaoToken = 40;
        }
    }
}