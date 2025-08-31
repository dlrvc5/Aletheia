using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewsAnalysisAPI.Models
{
    public class News
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("Başlık")]
        public string Title { get; set; } = null!;

        [BsonElement("Metin_İçerik")]
        public string Content { get; set; } = null!;

        [BsonElement("Yazar")]
        public string Author { get; set; } = null!;

        [BsonElement("Kaynak")]
        public string Source { get; set; } = null!;

        [BsonElement("Görsel_Link")]
        public string ImageUrl { get; set; } = null!;
    }
}
