namespace NewsAnalysisAPI.DTOs
{
    public class AnalysisResultDTO
    {
        public int NewsId { get; set; }
        public double ConsistencyScore { get; set; }
        public double MisinformationProbability { get; set; }
        public string AnalysisSummary { get; set; } = string.Empty;  // Boş string ile başlat
    }
}
