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
        
        [HttpGet()]
        public async Task<IActionResult> GetByPhrase([FromQuery(Name = "query")] string phrase)
        {
            var results = await _iResponseService.GetByPhrase(phrase);
            
            return Ok(results);
        }
        
    }
}