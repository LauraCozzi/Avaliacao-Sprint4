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
    public class CidadesConfiguration : IEntityTypeConfiguration<Cidades>
    {
        public void Configure(EntityTypeBuilder<Cidades> builder)
        {
            builder
                .ToTable("Cidades");           

            builder
                .Property(cidade => cidade.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");  

            builder
                .Property(cidade => cidade.Nome)
                .HasColumnName("Nome")  
                .HasColumnType("nvarchar(max)");              

            builder
                .Property(cidade => cidade.Populacao)
                .HasColumnName("Populacao")   
                .IsRequired();                

            builder
                .Property(cidade => cidade.TaxaCriminalidade)
                .HasColumnName("TaxaCriminalidade")
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(cidade => cidade.ImpostoSobreProduto)
                .HasColumnName("ImpostoSobreProduto")
                .HasColumnType("float")
                .IsRequired();

            builder
                .Property(cidade => cidade.EstadoCalamidade)
                .HasColumnName("EstadoCalamidade")
                .HasColumnType("bit")
                .IsRequired();

            builder
                .Property<DateTime?>("UltimaAtualizacao")
                .HasColumnType("datetime2(7)");
        }
    }
}
