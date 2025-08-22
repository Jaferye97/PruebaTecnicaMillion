using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ReporitoryMongoDb.Entities.Constants;

namespace ReporitoryMongoDb.Documents
{
    public class OwnerDocument : IDocument<Guid>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("address")]
        public string Address { get; set; } = null!;

        [BsonElement("photo")]
        public string Photo { get; set; } = null!;

        [BsonElement("birthday")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Birthday { get; set; }
    }
}
