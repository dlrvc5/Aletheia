using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewsAnalysisAPI.Models
{
    public class AnalysisResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string NewsId { get; set; } = string.Empty;

        public double ConsistencyScore { get; set; }
        public double MisinformationProbability { get; set; }
        public string AnalysisSummary { get; set; } = string.Empty;
    }
}

