using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Tres.ReportViewers.Models;

namespace Tres.ReportViewers.Services
{
    public class ReportViewerService : ServiceBase, IReportViewerService, IService
    {
        private readonly SiteState _siteState;

        public ReportViewerService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl=> CreateApiUrl(_siteState.Alias, "ReportViewer");

        public async Task<List<ReportViewer>> GetReportViewersAsync(int ModuleId)
        {
            List<ReportViewer> ReportViewers = await GetJsonAsync<List<ReportViewer>>($"{Apiurl}?moduleid={ModuleId}");
            return ReportViewers.OrderBy(item => item.Name).ToList();
        }

        public async Task<ReportViewer> GetReportViewerAsync(int ReportViewerId)
        {
            return await GetJsonAsync<ReportViewer>($"{Apiurl}/{ReportViewerId}");
        }

        public async Task<ReportViewer> AddReportViewerAsync(ReportViewer ReportViewer)
        {
            return await PostJsonAsync<ReportViewer>($"{Apiurl}?entityid={ReportViewer.ModuleId}", ReportViewer);
        }

        public async Task<ReportViewer> UpdateReportViewerAsync(ReportViewer ReportViewer)
        {
            return await PutJsonAsync<ReportViewer>($"{Apiurl}/{ReportViewer.ReportViewerId}?entityid={ReportViewer.ModuleId}", ReportViewer);
        }

        public async Task DeleteReportViewerAsync(int ReportViewerId)
        {
            await DeleteAsync($"{Apiurl}/{ReportViewerId}");
        }
    }
}
