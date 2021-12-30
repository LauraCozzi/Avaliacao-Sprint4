using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Cidades.Negocio
{
    public class Funcoes
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int NivelAcesso { get; set; }
        public IList<FuncoesFuncionarios> ListaFuncionarios { get; set; }

        public Funcoes()
        {
            ListaFuncionarios = new List<FuncoesFuncionarios>();
        }
    }
}
