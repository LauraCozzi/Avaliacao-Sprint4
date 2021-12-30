using EFCore_Cidades.Dados;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore_Cidades
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dados nova cidade
            string nomeCidade = "Ouro Preto";
            int populacao = 1000000;
            double taxaCriminalidade = 3;
            double impostoSobreProduto = 5;
            bool estadoCalamidade = false;

            using (var contexto = new CidadesContexto())
            {
                foreach (var cidade in contexto.Cidades)
                {
                    Console.WriteLine(cidade.Nome);
                }

                AdicionaCidade(contexto, nomeCidade, populacao, taxaCriminalidade, impostoSobreProduto, estadoCalamidade);
                MostrarFuncionarios(contexto);
            }

            Console.WriteLine("Pressione ENTER para sair...");
            Console.ReadKey();
        }

        public static void AdicionaCidade(CidadesContexto Contexto, string nomeCidade, int populacao, double taxaCriminalidade, double impostoSobreProduto, bool estadoCalamidade)
        {
            string SQL = "DECLARE @P_Id uniqueidentifier; SET @P_Id = NEWID();" +
                         "EXEC SP_ADD_CIDADE @P_Id, @P_Nome, @P_Populacao, @P_TaxaCriminalidade, @P_ImpostoSobreProduto, @P_EstadoCalamidade";

            List<SqlParameter> Parametros = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@P_Nome", Value = nomeCidade},
                new SqlParameter{ParameterName = "@P_Populacao", Value = populacao},
                new SqlParameter{ParameterName = "@P_TaxaCriminalidade", Value = taxaCriminalidade},
                new SqlParameter{ParameterName = "@P_ImpostoSobreProduto", Value = impostoSobreProduto},
                new SqlParameter{ParameterName = "@P_EstadoCalamidade", Value = estadoCalamidade},
            };

            Console.WriteLine($"\nAdicionando a cidade {nomeCidade}");
            Contexto.Database.ExecuteSqlRaw(SQL, Parametros);
            Console.WriteLine($"{nomeCidade} adicionada\n");
        }

        public static async Task MostrarFuncionarios(CidadesContexto contexto)
        {
            var resultado = await contexto.View.ToListAsync();
            foreach (var funcionario in resultado)
            {
                Console.WriteLine(funcionario.Nome);
            }
        }
    }
}
