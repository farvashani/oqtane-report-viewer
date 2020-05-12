using System.Collections.Generic;
using Tres.ReportViewers.Models;

namespace Tres.ReportViewers.Repository
{
    public interface IReportViewerRepository
    {
        IEnumerable<ReportViewer> GetReportViewers(int ModuleId);
        ReportViewer GetReportViewer(int ReportViewerId);
        ReportViewer AddReportViewer(ReportViewer ReportViewer);
        ReportViewer UpdateReportViewer(ReportViewer ReportViewer);
        void DeleteReportViewer(int ReportViewerId);
    }
}
