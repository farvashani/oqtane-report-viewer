using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Tres.ReportViewers.Models;

namespace Tres.ReportViewers.Repository
{
    public class ReportViewerContext : DBContextBase, IService
    {
        public virtual DbSet<ReportViewer> ReportViewer { get; set; }

        public ReportViewerContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
