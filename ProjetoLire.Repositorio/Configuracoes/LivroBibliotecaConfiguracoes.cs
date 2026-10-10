using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Configuracoes
{
    public class LivroBibliotecaConfiguracoes : IEntityTypeConfiguration<LivroBiblioteca>
    {
        public void Configure(EntityTypeBuilder<LivroBiblioteca> builder)
        {
            builder.ToTable("Livros_Bibliotecas").HasKey(biblioteca => biblioteca.Id);

            builder.Property(biblioteca => biblioteca.Id).HasColumnName("Id").IsRequired(true);
            builder.Property(biblioteca => biblioteca.UsuarioId).HasColumnName("UsuarioId").IsRequired(true);
            builder.Property(biblioteca => biblioteca.LivroId).HasColumnName("LivroId").IsRequired(true);
            builder.Property(biblioteca => biblioteca.StatusLeitura).HasColumnName("StatusLeitura").IsRequired(false);
            builder.Property(biblioteca => biblioteca.DataAdicionado).HasColumnName("DataAdicionado").IsRequired(true);

            builder
                .HasOne(biblioteca => biblioteca.Usuario)
                .WithMany(usuario => usuario.LivrosBiblioteca);
        }
    }
}