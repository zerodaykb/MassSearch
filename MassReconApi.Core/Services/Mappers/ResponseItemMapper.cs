using System;
using System.Collections.Generic;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ResponseItemMapper
    {
        public static ResponseItemDto MapShodanResponseItemToDto(ShodanResponseItem shodanResponse)
        {
            return new ResponseItemDto()
            {
                Ip = shodanResponse.Ip_str,
                Content = $"{shodanResponse.Org} - - - {shodanResponse.Data}",
                Source = "shodan"
            };
        }
        public static ResponseItemDto MapCensysResponseItemToDto(CensysResponseItem censysResponse)
        {
            return new ResponseItemDto()
            {
                Ip = censysResponse.Ip,
                Content = censysResponse.City,
                Source = "censys"
            };
        }
    }
}