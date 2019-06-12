using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Core.Services.Mappers;
using MassReconApi.Infrastucture.Repository;

namespace MassReconApi.Core.Services
{
    public class ReconNoteService : IReconNoteService
    {
        private readonly IReconNoteRepository _iReconNoteRepository;

        public ReconNoteService(IReconNoteRepository iReconNoteRepository)
        {
            _iReconNoteRepository = iReconNoteRepository;
        }

        public async Task<IEnumerable<ReconNoteDto>> GetAll()
        {
            var reconNotes = await _iReconNoteRepository.GetAll();
            return reconNotes
                .Select(ReconNoteMapper.MapReconNoteToDto)
                .ToList();
        }

        public async Task<ReconNoteDto> GetById(long id)
        {
            var reconNote = await _iReconNoteRepository.GetById(id);
            return ReconNoteMapper.MapReconNoteToDto(reconNote);
        }

        public async Task Add(ReconNoteDto reconNoteDto)
        {
            await _iReconNoteRepository.Add(ReconNoteMapper.MapDtoToReconNote(reconNoteDto));
        }

        public async Task Update(ReconNoteDto reconNoteDto)
        {
            await _iReconNoteRepository.Update(ReconNoteMapper.MapDtoToReconNote(reconNoteDto));
        }

        public async Task Delete(long id)
        {
            await _iReconNoteRepository.Delete(id);
        }
    }
}