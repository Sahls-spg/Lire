using Microsoft.EntityFrameworkCore;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Configuracoes;

namespace ProjetoLire.Repositorio.Contexto
{
    public class ProjetoLireContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<PlanoLeitura> Planos_De_Leitura { get; set; }
        public DbSet<Leitura> Leituras { get; set; }
        public DbSet<LivroBiblioteca> Livros_Bibliotecas { get; set; }

        public ProjetoLireContexto(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
            modelBuilder.ApplyConfiguration(new LivroConfiguracoes());
            modelBuilder.ApplyConfiguration(new LeituraConfiguracoes());
            modelBuilder.ApplyConfiguration(new PlanoLeituraConfiguracoes());
            modelBuilder.ApplyConfiguration(new LivroBibliotecaConfiguracoes());
        }
    }

}