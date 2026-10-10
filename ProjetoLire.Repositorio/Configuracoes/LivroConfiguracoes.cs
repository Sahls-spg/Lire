using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Configuracoes
{
    public class LivroConfiguracoes : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros").HasKey(livro => livro.Id);

            builder.Property(livro => livro.Id).HasColumnName("Id").IsRequired(true);
            builder.Property(livro => livro.Titulo).HasColumnName("Titulo").IsRequired(true);
            builder.Property(livro => livro.Autor).HasColumnName("Autor").IsRequired(true);
            builder.Property(livro => livro.GeneroLiterario).HasColumnName("GeneroLiterario").IsRequired(true);
            builder.Property(livro => livro.QuantidadeDePaginas).HasColumnName("QuantidadeDePaginas").IsRequired(true);
            builder.Property(livro => livro.Sinopse).HasColumnName("Sinopse").IsRequired(true);
        }
    }
}