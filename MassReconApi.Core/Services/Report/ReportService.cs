using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Core.Services.Mappers;
using MassReconApi.Infrastucture.Repository;

namespace MassReconApi.Core.Services
{
    
    public class ReportService : IReportService
    {
        private readonly IReportRepository _iReportRepository;

        public ReportService(IReportRepository iReportRepository)
        {
            _iReportRepository = iReportRepository;
        }
        
        
        public async Task<IEnumerable<ReportDto>> GetAll()
        {
            var reports = await _iReportRepository.GetAll();
            return reports
                .Select(ReportMapper.MapReportToDto)
                .ToList();
        }

        public async Task<ReportDto> GetById(long id)
        {
            var report = await _iReportRepository.GetById(id);
            return ReportMapper.MapReportToDto(report);
        }

        public async Task Add(ReportDto reportDto)
        {
            await _iReportRepository.Add(ReportMapper.MapDtoToReport(reportDto));
        }

        public async Task Update(ReportDto reportDto)
        {
            await _iReportRepository.Update(ReportMapper.MapDtoToReport(reportDto));
        }

        public async Task Delete(long id)
        {
            await _iReportRepository.Delete(id);
        }
    }
}