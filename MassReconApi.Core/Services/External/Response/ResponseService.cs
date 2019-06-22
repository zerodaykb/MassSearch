using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Core.Services.Mappers;
using MassReconApi.Infrastucture.Model;
using MassReconApi.Infrastucture.Repository;

namespace MassReconApi.Core.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseShodanRepository _iResponseShodanRepository;
        private readonly IResponseCensysRepository _iResponseCensysRepository;

        public ResponseService(IResponseShodanRepository iResponseShodanRepository, IResponseCensysRepository iResponseCensysRepository)
        {
            _iResponseShodanRepository = iResponseShodanRepository;
            _iResponseCensysRepository = iResponseCensysRepository;
        }
        
        public async Task<ResponseDto> GetByPhrase(string phrase, string type)
        {
            switch (type)
            {
                case "shodan":
                    var shodanResult = await _iResponseShodanRepository.GetByPhrase(phrase);
                    return ResponseMapper.MapShodanResponseToDto(shodanResult, phrase);
                
                case "censys":
                    var censysResult = await _iResponseCensysRepository.GetByPhrase(phrase);
                    return ResponseMapper.MapCensysResponseToDto(censysResult);
                
                default:
                    return null;
            } 
        }
    }
}