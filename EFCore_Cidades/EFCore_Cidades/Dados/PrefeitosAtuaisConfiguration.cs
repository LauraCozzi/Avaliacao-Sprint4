using EFCore_Cidades.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Cidades.Dados
{
    public class PrefeitosAtuaisConfiguration : IEntityTypeConfiguration<PrefeitosAtuais>
    {
        public void Configure(EntityTypeBuilder<PrefeitosAtuais> builder)
        {
            builder
                .ToTable("PrefeitosAtuais");

            // Primary Key
            builder
                .Property(cidade => cidade.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder
                .Property(cidade => cidade.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar(max)");

            builder
                .Property(cidade => cidade.InicioMandato)
                .HasColumnName("InicioMandato")
                .HasColumnType("datetime2(7)")
                .IsRequired();

            builder
                .Property(cidade => cidade.FimMandato)
                .HasColumnName("FimMandato")
                .HasColumnType("datetime2(7)")
                .IsRequired();

            builder
                .Property<DateTime?>("UltimaAtualizacao")
                .HasColumnType("datetime2(7)");

            // Foreign Key
            builder
                .HasOne(prefeito => prefeito.Cidade)
                .WithMany(cidade => cidade.ListaPrefeitos)
                .IsRequired();
        }
    }
}
