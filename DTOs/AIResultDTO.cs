namespace NewsAnalysisAPI.DTOs
{
    public class AIResultDTO
    {
        public double ConsistencyScore { get; set; }
        public double MisinformationProbability { get; set; }
        public string AnalysisSummary { get; set; } = string.Empty;
    }
}
