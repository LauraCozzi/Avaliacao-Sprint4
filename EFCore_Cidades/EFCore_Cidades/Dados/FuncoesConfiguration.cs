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
    public class FuncoesConfiguration : IEntityTypeConfiguration<Funcoes>
    {
        public void Configure(EntityTypeBuilder<Funcoes> builder)
        {
            builder
                .ToTable("Funcoes");

            builder
                .Property(cidade => cidade.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder
                .Property(cidade => cidade.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("nvarchar(max)");

            builder
                .Property(cidade => cidade.NivelAcesso)
                .HasColumnName("NivelAcesso")
                .IsRequired();

            builder
                .Property<DateTime?>("UltimaAtualizacao")
                .HasColumnType("datetime2(7)");
        }
    }
}
