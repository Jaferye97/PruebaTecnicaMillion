using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ReporitoryMongoDb.Entities.Constants;

namespace ReporitoryMongoDb.Documents
{
    public class PropertyImageDocument : IDocument<Guid>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [BsonElement("file")]
        public string File { get; set; } = null!;

        [BsonElement("enabled")]
        public bool Enabled { get; set; }

        [BsonElement("propertyId")]
        [BsonRepresentation(BsonType.String)]
        public Guid PropertyId { get; set; }
    }
}
