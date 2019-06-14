using System;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ReportItemMapper
    {
        public static ReportItemDto MapReportItemToDto(ReportItem reportItem)
        {
            return new ReportItemDto()
            {
                Id = reportItem.Id,
                Content = reportItem.Content,
                Notes = reportItem.Notes,
                SourceType = reportItem.SourceType,
                Ip = reportItem.Ip,
                IsChecked = reportItem.IsChecked
                
            };
        }

        public static ReportItem MapDtoToReportItem(ReportItemDto reportItemDto)
        {
            return new ReportItem()
            {
                Id = reportItemDto.Id.GetValueOrDefault(),
                Content = reportItemDto.Content,
                Notes = reportItemDto.Notes,
                SourceType = reportItemDto.SourceType,
                Ip = reportItemDto.Ip,
                IsChecked = reportItemDto.IsChecked
            };
        }
    }
}