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
    public class FunionariosConfiguration : IEntityTypeConfiguration<Funcionarios>
    {
        public void Configure(EntityTypeBuilder<Funcionarios> builder)
        {
            builder
               .ToTable("Funcionarios");

            // Primary key
            builder
                .Property(funcionario => funcionario.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder
                .Property(funcionario => funcionario.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar(max)");

            builder
                .Property(funcionario => funcionario.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime2(7)")
                .IsRequired();

            builder
                .Property<DateTime?>("UltimaAtualizacao")
                .HasColumnType("datetime2(7)");

            // Foreign Key
            builder.HasOne(funcionario => funcionario.Cidade)
                .WithMany(cidade => cidade.ListaFuncionarios)
                .HasForeignKey("CidadeId");
        }
    }
}
