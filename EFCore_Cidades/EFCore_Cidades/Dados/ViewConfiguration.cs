using EFCore_Cidades.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Cidades.Dados
{
    public class ViewConfiguration : IEntityTypeConfiguration<VW_ALL_FUNCIONARIOS>
    {
        public void Configure(EntityTypeBuilder<VW_ALL_FUNCIONARIOS> builder)
        {
            builder
                .ToTable("VW_ALL_FUNCIONARIOS");

            // Primary key
            builder
                .Property(funcionario => funcionario.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder
                .Property(funcionario => funcionario.Nome)
                .HasColumnName("Nome")
                .HasColumnType("nvarchar(max)");
        }
    }
}
