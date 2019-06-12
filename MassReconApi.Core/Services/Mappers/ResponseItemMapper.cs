using System;
using System.Collections.Generic;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ResponseItemMapper
    {
        public static ResponseItemDto MapResponseItemToDto(ResponseItem response)
        {
            return new ResponseItemDto()
            {
                Ip = response.Ip_str,
                Content = $"{response.Org} - - - {response.Data}",
                Source = "shodan"
            };
        }
    }
}