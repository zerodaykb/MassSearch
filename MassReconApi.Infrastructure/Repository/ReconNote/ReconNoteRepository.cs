using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Infrastucture.Context;
using MassReconApi.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;

namespace MassReconApi.Infrastucture.Repository
{
    public class ReconNoteRepository : IReconNoteRepository
    {
        private readonly MassReconContext _massReconContext;

        public ReconNoteRepository(MassReconContext massReconContext)
        {
            _massReconContext = massReconContext;
        }
        
        public async Task<IEnumerable<ReconNote>> GetAll()
        {
            var reconNotes = await _massReconContext.ReconNote.ToListAsync();
       
            return reconNotes;
        }

        public async Task<ReconNote> GetById(long id)
        {
            var reconNotes = await _massReconContext.ReconNote
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return reconNotes;
        }

        public async Task Add(ReconNote reconNote)
        {
            reconNote.DateOfCreation = DateTime.Now;
     
            await _massReconContext.ReconNote.AddAsync(reconNote);
            await _massReconContext.SaveChangesAsync();
        }

        public async Task Update(ReconNote reconNote)
        {
            var reconNoteToUpdate = await _massReconContext.ReconNote
                .SingleOrDefaultAsync(x => x.Id == reconNote.Id);

            if (reconNote != null)
            {
                reconNoteToUpdate.DateOfUpdate = DateTime.Now;
                reconNoteToUpdate.Text = reconNote.Text;

                await _massReconContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long id)
        {
            var reconNoteToDelete = await _massReconContext.ReconNote.SingleOrDefaultAsync(note => note.Id == id);
            if (reconNoteToDelete != null)
            {
                _massReconContext.ReconNote.Remove(reconNoteToDelete);
                await _massReconContext.SaveChangesAsync();
            }
        }
    }
}