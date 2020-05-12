using Oqtane.Models;
using Oqtane.Modules;

namespace Tres.ReportViewers.Modules
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "ReportViewer",
            Description = "ReportViewer",
            Version = "1.0.0",
            Dependencies = "Tres.ReportViewers.Shared.Oqtane",
            ServerManagerType = "Tres.ReportViewers.Manager.ReportViewerManager, Tres.ReportViewers.Server.Oqtane",
            ReleaseVersions = "1.0.0"
        };
    }
}
