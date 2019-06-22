using System.Collections.Generic;
using System.Linq;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ReportMapper
    {
        public static ReportDto MapReportToDto(Report report)
        {
            var reportItems = new List<ReportItemDto>();
            
            foreach (var reportItem in report.ReportItems)
            {
                reportItems.Add(ReportItemMapper.MapReportItemToDto(reportItem));
            }
            
            return new ReportDto()
            {
                Id = report.Id,
                SearchPhrase = report.SearchPhrase,
                Title = report.Title,
                Notes = report.Notes,
                Status = report.Status,
                Quantity = report.Quantity,
                ReportItems = reportItems
            };
        }

        public static Report MapDtoToReport(ReportDto reportDto)
        {
            var reportItems = new List<ReportItem>();
            
            if (reportDto.ReportItems != null)
            { 
                foreach (var reportItemDto in reportDto.ReportItems)
                {
                    reportItems.Add(ReportItemMapper.MapDtoToReportItem(reportItemDto));
                }
            }
            
            
            return new Report()
            {
                Id = reportDto.Id.GetValueOrDefault(),
                SearchPhrase = reportDto.SearchPhrase,
                Title = reportDto.Title,
                Notes = reportDto.Notes,
                Status = reportDto.Status,
                Quantity = reportDto.Quantity,
                ReportItems = reportItems
            };
        }
    }
}