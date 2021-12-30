using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Cidades.Negocio
{
    public class PrefeitosAtuais
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime InicioMandato { get; set; }
        public DateTime FimMandato { get; set; }
        public Cidades Cidade { get; set; }
    }
}
