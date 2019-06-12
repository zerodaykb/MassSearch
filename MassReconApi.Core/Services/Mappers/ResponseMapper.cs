using System;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ResponseMapper
    {
        public static ResponseDto MapResponseToDto(Response response, string phrase)
        {
            return new ResponseDto()
            {
                SearchPhrase = phrase,
                NumberOfItems = response.Total,
                //ResponseItems = response.Matches
                
            };
        }
    }
}