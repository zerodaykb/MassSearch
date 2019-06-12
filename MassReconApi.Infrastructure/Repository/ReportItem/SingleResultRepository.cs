using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Infrastucture.Context;
using MassReconApi.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;

namespace MassReconApi.Infrastucture.Repository
{
    public class ReportItemRepository : IReportItemRepository
    {
        private readonly MassReconContext _massReconContext;

        public ReportItemRepository(MassReconContext massReconContext)
        {
            _massReconContext = massReconContext;
        }
        
        public async Task<IEnumerable<ReportItem>> GetAll()
        {
            var results = await _massReconContext.SingleResult.ToListAsync();
            results.ForEach(x =>
            {
                _massReconContext.Entry(x).Reference(y => y.Report).LoadAsync();
            });

            return results;
        }

        public async Task<ReportItem> GetById(long id)
        {
            var result = await _massReconContext.SingleResult
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            await _massReconContext.Entry(result).Reference(x => x.Report).LoadAsync();
            return result;
        }

        public async Task Add(ReportItem result)
        {
            result.DateOfCreation = DateTime.Now;
            await _massReconContext.SingleResult
                .Include(x => x.Report)
                .FirstAsync();
            await _massReconContext.SingleResult.AddAsync(result);
            await _massReconContext.SaveChangesAsync();
        }

        public async Task Update(ReportItem result)
        {
            var resultToUpdate = await _massReconContext.SingleResult
                .Include(x => x.Report)
                .SingleOrDefaultAsync(x => x.Id == result.Id);

            if (resultToUpdate != null)
            {
                resultToUpdate.DateOfUpdate = DateTime.Now;
                resultToUpdate.Notes = result.Notes;
                resultToUpdate.Content = result.Content;
                resultToUpdate.IsChecked = result.IsChecked;
                resultToUpdate.SourceType = result.SourceType;
             
                if (resultToUpdate.Report != null && result.Report != null)
                {
                    result.Report.Id = resultToUpdate.Report.Id;
                    _massReconContext.Entry(resultToUpdate.Report).CurrentValues.SetValues(result.Report);
                }

                await _massReconContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long id)
        {
            var resultToDelete = await _massReconContext.SingleResult.SingleOrDefaultAsync(result => result.Id == id);
            if (resultToDelete != null)
            {
                _massReconContext.SingleResult.Remove(resultToDelete);
                await _massReconContext.SaveChangesAsync();
            }
        }
    }
}