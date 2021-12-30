using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditoriaPedidos.Modelos
{
    public class PedidoPaginado
    {
		public int pageNumber { get; set; }
		public int pageSize { get; set; }
		public List<Pedido> itens { get; set; }

		public PedidoPaginado(int numeroPagina, int tamanhoPagina, List<Pedido> listaPedidos)
		{
			this.pageNumber = numeroPagina;
			this.pageSize = tamanhoPagina;
			this.itens = listaPedidos;
		}
	}
}
