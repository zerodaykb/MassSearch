using System;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
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
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNote(long id)
        {
            try
            {
                var note = await _iReconNoteService.GetById(id);
                return Ok(note);
            }
            catch (NullReferenceException e)
            {
                return NotFound($"Can't find note with id = {id}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] ReconNoteDto reconNoteDto)
        {
            if (reconNoteDto == null)
            {
                return BadRequest();
            }

            await _iReconNoteService.Add(reconNoteDto);
            return Created("Created new note", reconNoteDto);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateReport([FromBody] ReconNoteDto reconNoteDto)
        {
            if (reconNoteDto == null)
            {
                return BadRequest();
            }

            await _iReconNoteService.Update(reconNoteDto);
            return Ok($"Updated note with id = {reconNoteDto.Id}");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReport(long id)
        {
            await _iReconNoteService.Delete(id);
            return Ok($"Report with id = {id} deleted");
        }
  
    }
}