using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Cidades.Negocio
{
    public class Cidades
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Populacao { get; set; }
        public double TaxaCriminalidade { get; set; }
        public double ImpostoSobreProduto { get; set; }
        public bool EstadoCalamidade { get; set; }
        public List<Funcionarios> ListaFuncionarios { get; set; }
        public List<PrefeitosAtuais> ListaPrefeitos { get; set; }
    }
}
