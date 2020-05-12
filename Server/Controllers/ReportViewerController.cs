using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Tres.ReportViewers.Models;
using Tres.ReportViewers.Repository;

namespace Tres.ReportViewers.Controllers
{
    [Route("{site}/api/[controller]")]
    public class ReportViewerController : Controller
    {
        private readonly IReportViewerRepository _ReportViewers;
        private readonly ILogManager _logger;

        public ReportViewerController(IReportViewerRepository ReportViewers, ILogManager logger)
        {
            _ReportViewers = ReportViewers;
            _logger = logger;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Roles = Constants.RegisteredRole)]
        public IEnumerable<ReportViewer> Get(string moduleid)
        {
            return _ReportViewers.GetReportViewers(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = Constants.RegisteredRole)]
        public ReportViewer Get(int id)
        {
            return _ReportViewers.GetReportViewer(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = Constants.AdminRole)]
        public ReportViewer Post([FromBody] ReportViewer ReportViewer)
        {
            if (ModelState.IsValid)
            {
                ReportViewer = _ReportViewers.AddReportViewer(ReportViewer);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "ReportViewer Added {ReportViewer}", ReportViewer);
            }
            return ReportViewer;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public ReportViewer Put(int id, [FromBody] ReportViewer ReportViewer)
        {
            if (ModelState.IsValid)
            {
                ReportViewer = _ReportViewers.UpdateReportViewer(ReportViewer);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "ReportViewer Updated {ReportViewer}", ReportViewer);
            }
            return ReportViewer;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public void Delete(int id)
        {
            _ReportViewers.DeleteReportViewer(id);
            _logger.Log(LogLevel.Information, this, LogFunction.Delete, "ReportViewer Deleted {ReportViewerId}", id);
        }
    }
}
