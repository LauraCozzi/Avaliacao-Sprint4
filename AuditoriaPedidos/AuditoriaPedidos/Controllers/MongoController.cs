using AuditoriaPedidos.BancoDeDados;
using AuditoriaPedidos.Modelos;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditoriaPedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MongoController : ControllerBase
    {
        private static readonly AcessoMongo mongo = new AcessoMongo();
 
        // MÉTODOS HTTP

        // https://localhost:5001/api/Mongo/inserir url para a inserir
        [HttpPost("inserir")]
        public IActionResult InserirPedido([FromBody] Pedido pedido)
        {
            InserePedidoAsync(pedido);
            return Ok();
        }

        // https://localhost:5001/api/Mongo/listaPedidos url para resgatar todos os pedidos
        [HttpGet("listaPedidos")]
        public IActionResult RecuperarPedidos()
        {
            List<Pedido> listaPedidos = TodosPedidos().Result;
            return Ok(listaPedidos);
        }

        // página inicia no 0
        // ignora os elementos que se encontram antes da requisição do usuário e pega os próximos até chegar no limte de elementos (tamPagina)
        // https://localhost:5001/api/Mongo/listaPedidosPaginacao?numeroPagina=3&tamanhoPagina=5 url para resgatar os pedidos de acordo com a quantidade passada
        [HttpGet("listaPedidosPaginacao")]
        public IActionResult RecuperarPedidosPaginados([FromQuery(Name = "numeroPagina")] int indexPagina, [FromQuery(Name = "tamanhoPagina")] int tamanhoPagina)
        {
            List<Pedido> pedidos = TodosPedidos().Result.Skip(indexPagina * tamanhoPagina).Take(tamanhoPagina).ToList();
            PedidoPaginado pedidoPaginado = new PedidoPaginado(indexPagina, tamanhoPagina, pedidos);
            return Ok(pedidoPaginado);
        }
        public static async Task<List<Pedido>> TodosPedidos()
        {
            List<Pedido> listaPedidos = await mongo.Pedidos.Find(pedido => pedido.Id != null).ToListAsync();
            return listaPedidos;
        }

        public static async void InserePedidoAsync(Pedido pedido)
        {
            await mongo.Pedidos.InsertOneAsync(pedido);
        }
        
    }
}
