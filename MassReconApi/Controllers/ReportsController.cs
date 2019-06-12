using System;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MassReconApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _iReportsService;

        public ReportsController(IReportService iReportsService)
        {
            _iReportsService = iReportsService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var reports = await _iReportsService.GetAll();
            return Ok(reports);
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetReportById(long id)
        {
            try
            {
                var report = await _iReportsService.GetById(id);
                return Ok(report);
            }
            catch (NullReferenceException e)
            {
                return NotFound($"Can't find report with id = {id}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportDto reportDto)
        {
            if (reportDto == null)
            {
                return BadRequest();
            }

            await _iReportsService.Add(reportDto);
            return Created("Created new report", reportDto);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody] ReportDto reportDto)
        {
            if (reportDto == null)
            {
                return BadRequest();
            }

            await _iReportsService.Update(reportDto);
            return Ok($"Updated report with id = {reportDto.Id}");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteFlat(long id)
        {
            await _iReportsService.Delete(id);
            return Ok($"Report with id = {id} deleted");
        }
        
    }
}