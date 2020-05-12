using System.Collections.Generic;
using System.Threading.Tasks;
using Tres.ReportViewers.Models;

namespace Tres.ReportViewers.Services
{
    public interface IReportViewerService 
    {
        Task<List<ReportViewer>> GetReportViewersAsync(int ModuleId);

        Task<ReportViewer> GetReportViewerAsync(int ReportViewerId);

        Task<ReportViewer> AddReportViewerAsync(ReportViewer ReportViewer);

        Task<ReportViewer> UpdateReportViewerAsync(ReportViewer ReportViewer);

        Task DeleteReportViewerAsync(int ReportViewerId);
    }
}
