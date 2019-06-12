using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services.Mappers
{
    internal static class ReconNoteMapper
    {
        public static ReconNoteDto MapReconNoteToDto(ReconNote reconNote)
        {
            return new ReconNoteDto()
            {
                Text = reconNote.Text
            };
        }

        public static ReconNote MapDtoToReconNote(ReconNoteDto reconNoteDto)
        {
            return new ReconNote()
            {
                Text = reconNoteDto.Text
            };
        }
    }
}