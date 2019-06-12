using System.Threading.Tasks;
using MassReconApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MassReconApi.Controllers
{
    [ApiController]
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
    }
}