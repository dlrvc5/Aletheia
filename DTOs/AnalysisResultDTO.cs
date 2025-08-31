namespace NewsAnalysisAPI.DTOs
{
    public class AnalysisResultDTO
    {
        public string NewsId { get; set; } = string.Empty;  
        public double ConsistencyScore { get; set; }
        public double MisinformationProbability { get; set; }
        public string AnalysisSummary { get; set; } = string.Empty;
    }
}
