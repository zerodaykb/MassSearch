using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ReportMapper
    {
        public static ReportDto MapReportToDto(Report report)
        {
            return new ReportDto()
            {
                Id = report.Id,
                SearchPhrase = report.SearchPhrase,
                Notes = report.Notes,
                Status = report.Status,
                Quantity = report.Quantity
            };
        }

        public static Report MapDtoToReport(ReportDto reportDto)
        {
            return new Report()
            {
                Id = reportDto.Id.GetValueOrDefault(),
                SearchPhrase = reportDto.SearchPhrase,
                Notes = reportDto.Notes,
                Status = reportDto.Status,
                Quantity = reportDto.Quantity
            };
        }
    }
}