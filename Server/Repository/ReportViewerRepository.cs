using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Tres.ReportViewers.Models;

namespace Tres.ReportViewers.Repository
{
    public class ReportViewerRepository : IReportViewerRepository, IService
    {
        private readonly ReportViewerContext _db;

        public ReportViewerRepository(ReportViewerContext context)
        {
            _db = context;
        }

        public IEnumerable<ReportViewer> GetReportViewers(int ModuleId)
        {
            return _db.ReportViewer.Where(item => item.ModuleId == ModuleId);
        }

        public ReportViewer GetReportViewer(int ReportViewerId)
        {
            return _db.ReportViewer.Find(ReportViewerId);
        }

        public ReportViewer AddReportViewer(ReportViewer ReportViewer)
        {
            _db.ReportViewer.Add(ReportViewer);
            _db.SaveChanges();
            return ReportViewer;
        }

        public ReportViewer UpdateReportViewer(ReportViewer ReportViewer)
        {
            _db.Entry(ReportViewer).State = EntityState.Modified;
            _db.SaveChanges();
            return ReportViewer;
        }

        public void DeleteReportViewer(int ReportViewerId)
        {
            ReportViewer ReportViewer = _db.ReportViewer.Find(ReportViewerId);
            _db.ReportViewer.Remove(ReportViewer);
            _db.SaveChanges();
        }
    }
}
