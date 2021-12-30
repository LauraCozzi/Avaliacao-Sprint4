using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuditoriaPedidos.Modelos
{
    public class Pedido
    {
        [JsonIgnore] // Não mostra o atributo no JSON
        [BsonRepresentation(BsonType.ObjectId)] // conversão de sting para ObjectId
        public string Id { get; set; }
        public string orderID { get; set; }
        public DateTime eventDate { get; set; }
        public string description { get; set; }
        public string api { get; set; }
        public Content content { get; set; }
    }
}
