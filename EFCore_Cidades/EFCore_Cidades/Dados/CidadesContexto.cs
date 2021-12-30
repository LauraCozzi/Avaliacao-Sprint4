using EFCore_Cidades.Negocio;
using EFCore_Cidades.Procedures;
using EFCore_Cidades.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Cidades.Dados
{
    public class CidadesContexto : DbContext
    {
        public DbSet<Cidades> Cidades { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
        public DbSet<Funcoes> Funcoes { get; set; }
        public DbSet<FuncoesFuncionarios> FuncoesFuncionarios { get; set; }
        public DbSet<PrefeitosAtuais> PrefeitosAtuais { get; set; }
        public DbSet<VW_ALL_FUNCIONARIOS> View { get; set; }
        public DbSet<SP_ADD_CIDADE> AdiconarCidade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cidades;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadesConfiguration());
            modelBuilder.ApplyConfiguration(new FunionariosConfiguration());
            modelBuilder.ApplyConfiguration(new FuncoesConfiguration());
            modelBuilder.ApplyConfiguration(new FuncoesFuncinariosConfiguration());
            modelBuilder.ApplyConfiguration(new PrefeitosAtuaisConfiguration());
            modelBuilder.Entity<ViewConfiguration>().ToView("VW_ALL_FUNCIONARIOS").HasNoKey();
        }
    }
}
