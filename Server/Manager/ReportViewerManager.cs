using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Tres.ReportViewers.Models;
using Tres.ReportViewers.Repository;

namespace Tres.ReportViewers.Manager
{
    public class ReportViewerManager : IInstallable, IPortable
    {
        private IReportViewerRepository _ReportViewers;
        private ISqlRepository _sql;

        public ReportViewerManager(IReportViewerRepository ReportViewers, ISqlRepository sql)
        {
            _ReportViewers = ReportViewers;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Tres.ReportViewer." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Tres.ReportViewer.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<ReportViewer> ReportViewers = _ReportViewers.GetReportViewers(module.ModuleId).ToList();
            if (ReportViewers != null)
            {
                content = JsonSerializer.Serialize(ReportViewers);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<ReportViewer> ReportViewers = null;
            if (!string.IsNullOrEmpty(content))
            {
                ReportViewers = JsonSerializer.Deserialize<List<ReportViewer>>(content);
            }
            if (ReportViewers != null)
            {
                foreach(ReportViewer ReportViewer in ReportViewers)
                {
                    ReportViewer _ReportViewer = new ReportViewer();
                    _ReportViewer.ModuleId = module.ModuleId;
                    _ReportViewer.Name = ReportViewer.Name;
                    _ReportViewers.AddReportViewer(_ReportViewer);
                }
            }
        }
    }
}