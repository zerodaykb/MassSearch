using System;
using System.Collections.Generic;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ResponseMapper
    {
        public static ResponseDto MapResponseToDto(Response response, string phrase)
        {

            var responseItems = new List<ResponseItemDto>();

            foreach (var match in response.Matches)
            {
                responseItems.Add(ResponseItemMapper.MapResponseItemToDto(match));
            }

            return new ResponseDto()
            {
                Query = phrase,
                Quantity = response.Total,
                Items = responseItems
            };
        }
    }
}