using System.Collections.Generic;

namespace MassReconApi.Contract.Dto
{
    public class ReportDto
    {
        public long? Id { get; set; }
        public string SearchPhrase { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }

        public List<ReportItemDto> ReportItems { get; set; }
    }
}