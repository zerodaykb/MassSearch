using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassReconApi.Infrastucture.Context;
using MassReconApi.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;

namespace MassReconApi.Infrastucture.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly MassReconContext _massReconContext;

        public ReportRepository(MassReconContext massReconContext)
        {
            _massReconContext = massReconContext;
        }

        public async Task<IEnumerable<Report>> GetAll()
        {
            var reports = await _massReconContext.Report.ToListAsync();
            reports.ForEach(x =>
            {
                _massReconContext.Entry(x).Collection(y => y.ReportItems).LoadAsync();
            });

            return reports;
        }

        public async Task<Report> GetById(long id)
        {
            var report = await _massReconContext.Report
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            await _massReconContext.Entry(report).Collection(x => x.ReportItems).LoadAsync();
            return report;
        }

        public async Task Add(Report report)
        {
            report.DateOfCreation = DateTime.Now;
            await _massReconContext.Report
                .Include(x => x.ReportItems)
                .FirstOrDefaultAsync();
            await _massReconContext.Report.AddAsync(report);
            await _massReconContext.SaveChangesAsync();
        }

        public async Task Update(Report report)
        {
            var reportToUpdate = await _massReconContext.Report
                .Include(x => x.ReportItems)
                .SingleOrDefaultAsync(x => x.Id == report.Id);

            if (reportToUpdate != null)
            {
                reportToUpdate.DateOfUpdate = DateTime.Now;
                reportToUpdate.Notes = report.Notes;
                reportToUpdate.Status = report.Status;
                reportToUpdate.SearchPhrase = report.SearchPhrase;

                if (reportToUpdate.ReportItems != null && report.ReportItems != null)
                {
                    var resultsToUpdate = reportToUpdate.ReportItems.ToList();
                    
                    foreach (var result in resultsToUpdate)
                    {
                        foreach (var entityResult in report.ReportItems)
                        {
                            if (result.Id == entityResult.Id)
                            {
                                _massReconContext.Entry(result).CurrentValues.SetValues(entityResult);
                            }
                        }
                    }
                }

                await _massReconContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long id)
        {
            var reportToDelete = await _massReconContext.Report.SingleOrDefaultAsync(report => report.Id == id);
            if (reportToDelete != null)
            {
                _massReconContext.Report.Remove(reportToDelete);
                await _massReconContext.SaveChangesAsync();
            }
        }
    }
}