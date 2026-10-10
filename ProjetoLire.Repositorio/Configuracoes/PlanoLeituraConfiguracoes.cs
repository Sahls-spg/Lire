using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLire.Dominio.Entidades;

namespace ProjetoLire.Repositorio.Configuracoes
{
    public class PlanoLeituraConfiguracoes : IEntityTypeConfiguration<PlanoLeitura>
    {
        public void Configure(EntityTypeBuilder<PlanoLeitura> builder)
        {
            builder.ToTable("Planos_De_Leitura").HasKey(plano => plano.Id);

            builder.Property(plano => plano.Id).HasColumnName("Id").IsRequired(true);
            builder.Property(plano => plano.UsuarioId).HasColumnName("UsuarioId").IsRequired(true);
            builder.Property(plano => plano.LivroId).HasColumnName("LivroId").IsRequired(true);
            builder.Property(plano => plano.DataInicio).HasColumnName("DataInicio").IsRequired(true);
            builder.Property(plano => plano.TempoDiarioPraLer).HasColumnName("TempoDiarioPraLer").IsRequired(true);
            builder.Property(plano => plano.DiasDisponiveisParaLer).HasColumnName("DiasDisponiveisParaLer").IsRequired(true);
            builder.Property(plano => plano.PaginasPorDia).HasColumnName("PaginasPorDia").IsRequired(true);
            builder.Property(plano => plano.DataPrevisaoTermino).HasColumnName("DataPrevisaoTermino").IsRequired(true);

            builder
                .HasOne(planoLeitura => planoLeitura.Usuario)
                .WithMany(usuario => usuario.PlanosLeitura)
                .HasForeignKey(planoLeitura => planoLeitura.UsuarioId);
        }
    }
}