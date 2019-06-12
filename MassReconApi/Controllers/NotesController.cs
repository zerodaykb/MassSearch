using System.Threading.Tasks;
using MassReconApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MassReconApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly IReconNoteService _iReconNoteService;

        public NotesController(IReconNoteService iReconNoteService)
        {
            _iReconNoteService = iReconNoteService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _iReconNoteService.GetAll();
            return Ok(notes);
        }
  
    }
}