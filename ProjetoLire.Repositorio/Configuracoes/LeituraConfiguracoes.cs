using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Configuracoes
{
    public class LeituraConfiguracoes : IEntityTypeConfiguration<Leitura>
    {
        public void Configure(EntityTypeBuilder<Leitura> builder)
        {
            builder.ToTable("Leituras").HasKey(leitura => leitura.Id);

            builder.Property(leitura => leitura.Id).HasColumnName("Id").IsRequired(true);
            builder.Property(leitura => leitura.UsuarioId).HasColumnName("UsuarioId").IsRequired(true);
            builder.Property(leitura => leitura.LivroId).HasColumnName("LivroId").IsRequired(true);
            builder.Property(leitura => leitura.PaginaAtual).HasColumnName("Leitura").IsRequired(true);
            builder.Property(leitura => leitura.DataRegistro).HasColumnName("DataRegistro").IsRequired(true);

            builder
                .HasOne(leitura => leitura.Usuario)
                .WithMany(usuario => usuario.Leituras)
                .HasForeignKey(leitura => leitura.UsuarioId);
        }
    }
}