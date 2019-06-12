using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Core.Services.Mappers;
using MassReconApi.Infrastucture.Model;
using MassReconApi.Infrastucture.Repository;

namespace MassReconApi.Core.Services
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseExternalRepository _iResponseExternalRepository;

        public ResponseService(IResponseExternalRepository iResponseExternalRepository)
        {
            _iResponseExternalRepository = iResponseExternalRepository;
        }
        
        public async Task<ResponseDto> GetByPhrase(string phrase)
        {
            var result = await _iResponseExternalRepository.GetByPhrase(phrase);
            
            return ResponseMapper.MapResponseToDto(result, phrase);
        }
    }
}