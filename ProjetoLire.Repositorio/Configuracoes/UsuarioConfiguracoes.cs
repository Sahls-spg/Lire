using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Configuracoes
{
    public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios").HasKey(usuario => usuario.Id);

            builder.Property(usuario => usuario.Id).HasColumnName("Id").IsRequired(true);
            builder.Property(usuario => usuario.Nome).HasColumnName("Nome").IsRequired(true);
            builder.Property(usuario => usuario.Sobrenome).HasColumnName("Sobrenome").IsRequired(true);
            builder.Property(usuario => usuario.Genero).HasColumnName("Genero").IsRequired(true);
            builder.Property(usuario => usuario.Email).HasColumnName("Email").IsRequired(true);
            builder.Property(usuario => usuario.Senha).HasColumnName("Senha").IsRequired(true);
            builder.Property(usuario => usuario.DataNascimento).HasColumnName("DataNascimento").IsRequired(true);
            builder.Property(usuario => usuario.DataCriacaoDaConta).HasColumnName("DataCriacaoDaConta").IsRequired(true);

            builder
                .HasMany(usuario => usuario.LivrosBiblioteca)
                .WithOne(biblioteca => biblioteca.Usuario);
        }
    }
}