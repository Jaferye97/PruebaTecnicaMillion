using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ReporitoryMongoDb.Entities.Constants;

namespace ReporitoryMongoDb.Documents
{
    public class PropertyDocument : IDocument<Guid>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("address")]
        public string Address { get; set; } = null!;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("codeInternal")]
        public string CodeInternal { get; set; } = null!;

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("ownerId")]
        [BsonRepresentation(BsonType.String)]
        public Guid OwnerId { get; set; }
    }
}
