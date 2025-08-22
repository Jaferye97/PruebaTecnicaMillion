using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ReporitoryMongoDb.Entities.Constants;

namespace ReporitoryMongoDb.Documents
{
    public class PropertyTraceDocument : IDocument<Guid>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [BsonElement("dateSale")]
        public DateTime DateSale { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("value")]
        public decimal Value { get; set; }

        [BsonElement("tax")]
        public decimal Tax { get; set; }

        [BsonElement("propertyId")]
        [BsonRepresentation(BsonType.String)]
        public Guid PropertyId { get; set; }
    }
}
