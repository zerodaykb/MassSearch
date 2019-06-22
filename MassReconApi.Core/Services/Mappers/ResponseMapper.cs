using System;
using System.Collections.Generic;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ResponseMapper
    {
        public static ResponseDto MapShodanResponseToDto(ShodanResponse shodanResponse, string phrase)
        {

            var responseItems = new List<ResponseItemDto>();

            foreach (var match in shodanResponse.Matches)
            {
                responseItems.Add(ResponseItemMapper.MapShodanResponseItemToDto(match));
            }

            return new ResponseDto()
            {
                Query = phrase,
                Quantity = shodanResponse.Total,
                Items = responseItems
            };
        }
        
        public static ResponseDto MapCensysResponseToDto(CensysResponse censysResponse)
        {

            var responseItems = new List<ResponseItemDto>();

            foreach (var match in censysResponse.Results)
            {
                responseItems.Add(ResponseItemMapper.MapCensysResponseItemToDto(match));
            }

            return new ResponseDto()
            {
                Query = censysResponse.metadata.Query,
                Quantity = censysResponse.metadata.Count,
                Items = responseItems
            };
        }
    }
}