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
    public class FuncoesFuncinariosConfiguration : IEntityTypeConfiguration<FuncoesFuncionarios>
    {
        public void Configure(EntityTypeBuilder<FuncoesFuncionarios> builder)
        {
            builder.ToTable("FuncoesFuncionarios");

            builder.Property<Guid>("FuncionarioId").IsRequired();
            builder.Property<Guid>("FuncaoId").IsRequired();

            builder.HasKey("FuncionarioId", "FuncaoId");

            // chave estrangeira
            // 1 funcionário possui 1 a N função
            // 1 função pode possuir de 1 a N funcionários
            builder.HasOne(fa => fa.Funcionarios)
                .WithMany(f => f.FuncaoFuncionario)
                .HasForeignKey("FuncionarioId");

            builder.HasOne(fa => fa.Funcoes)
                .WithMany(f => f.ListaFuncionarios)
                .HasForeignKey("FuncaoId");
        }
    }
}
