using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Core.Services.Mappers;
using MassReconApi.Infrastucture.Repository;

namespace MassReconApi.Core.Services
{
   
    public class ReportItemService : IReportItemService
    {
        private readonly IReportItemRepository _iReportItemRepository;

        public ReportItemService(IReportItemRepository iReportItemRepository)
        {
            _iReportItemRepository = iReportItemRepository;
        }
        
        
        public async Task<IEnumerable<ReportItemDto>> GetAll()
        {
            var results = await _iReportItemRepository.GetAll();
            return results
                .Select(ReportItemMapper.MapReportItemToDto)
                .ToList();
        }

        public async Task<ReportItemDto> GetById(long id)
        {
            var singleResult = await _iReportItemRepository.GetById(id);
            return ReportItemMapper.MapReportItemToDto(singleResult);
        }

        public async Task Add(ReportItemDto singleResultDto)
        {
            await _iReportItemRepository.Add(ReportItemMapper.MapDtoToReportItem(singleResultDto));
        }

        public async Task Update(ReportItemDto singleResultDto)
        {
            await _iReportItemRepository.Update(ReportItemMapper.MapDtoToReportItem(singleResultDto));
        }

        public async Task Delete(long id)
        {
            await _iReportItemRepository.Delete(id);
        }
    }
}