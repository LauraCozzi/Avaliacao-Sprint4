using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Cidades.Negocio
{
    public class Funcionarios
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public IList<FuncoesFuncionarios> FuncaoFuncionario { get; set; }
        public Cidades Cidade { get; set; }

    }
}
