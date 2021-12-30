using AuditoriaPedidos.Modelos;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditoriaPedidos.BancoDeDados
{
    public class AcessoMongo
    {
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DO_DATABASE = "BancoDeDadosPedido";
        public const string NOME_DA_COLECAO = "ColecaoPedidos";

        private static readonly IMongoClient _cliente;
        private static readonly IMongoDatabase _BaseDados;

        static AcessoMongo()
        {
            _cliente = new MongoClient(STRING_DE_CONEXAO);
            _BaseDados = _cliente.GetDatabase(NOME_DO_DATABASE);
        }

        public IMongoClient Cliente
        {
            get { return _cliente; }
        }

        public IMongoCollection<Pedido> Pedidos
        {
            get { return _BaseDados.GetCollection<Pedido>(NOME_DA_COLECAO); }
        }
    }
}
