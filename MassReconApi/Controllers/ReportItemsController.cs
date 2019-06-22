using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Core.Services;
using MassReconApi.Infrastucture.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MassReconApi.Controllers
{
    [ApiController]
    [EnableCors("cors")]
    [Route("api/[controller]")]
    public class ReportItemsController : ControllerBase
    {
        private readonly IReportItemService _iReportItemService;

        public ReportItemsController(IReportItemService iReportItemService)
        {
            _iReportItemService = iReportItemService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            var notes = await _iReportItemService.GetAll(); 
            return Ok(notes);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateReportItem([FromBody] ReportItemDto reportItemDto)
        {
            if (reportItemDto == null)
            {
                return BadRequest();
            }

            await _iReportItemService.Update(reportItemDto);
            return Ok($"Updated report with id = {reportItemDto.Id}");
        }
    }
}