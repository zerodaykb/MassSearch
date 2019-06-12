using System.Collections.Generic;

namespace MassReconApi.Infrastucture.Model
{
    public class ReportItem : Entity
    {
        public string Content { get; set; } 
        public string Notes { get; set; }
        public string SourceType { get; set; }
        public string Ip { get; set; }
        public bool IsChecked { get; set; }
        
        public Report Report { get; set; }
    }
}