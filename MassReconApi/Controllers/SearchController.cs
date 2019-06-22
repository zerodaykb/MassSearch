using System.Threading.Tasks;
using MassReconApi.Core.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MassReconApi.Controllers
{
    [ApiController]
    [EnableCors("cors")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    
    public class SearchController : ControllerBase
    {
        private readonly IResponseService _iResponseService;

        public SearchController(IResponseService iResponseService)
        {
            _iResponseService = iResponseService;
        } 
        
        [HttpGet]
        public async Task<IActionResult> GetByPhrase(
            [FromQuery(Name = "query")] string phrase,
            [FromQuery(Name = "type")] string type
            )
        {
            var results = await _iResponseService.GetByPhrase(phrase, type);
            
            return Ok(results);
        }
    }
}