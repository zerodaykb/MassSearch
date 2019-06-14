namespace MassReconApi.Contract.Dto
{
    public class ReportItemDto
    {
        public long? Id { get; set; }
        public string Content { get; set; } 
        public string Notes { get; set; }
        public string SourceType { get; set; }
        public string Ip { get; set; }
        public bool IsChecked { get; set; }
    }
}