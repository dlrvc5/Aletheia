namespace NewsAnalysisAPI.Models
{
    public class AnalysisResult
    {
        public int Id { get; set; }
        public double ConsistencyPercentage { get; set; }
        public string AnalysisDetails { get; set; }
    }
}
