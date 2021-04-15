using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Flashcardgenerator.Data;

namespace Flashcardgenerator
{
    public partial class ExportLocalhostController : ExportController
    {
        private readonly LocalhostContext context;

        public ExportLocalhostController(LocalhostContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/Localhost/briefs/csv")]
        [HttpGet("/export/Localhost/briefs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBriefsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Briefs, Request.Query), fileName);
        }

        [HttpGet("/export/Localhost/briefs/excel")]
        [HttpGet("/export/Localhost/briefs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBriefsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Briefs, Request.Query), fileName);
        }
        [HttpGet("/export/Localhost/cards/csv")]
        [HttpGet("/export/Localhost/cards/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCardsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Cards, Request.Query), fileName);
        }

        [HttpGet("/export/Localhost/cards/excel")]
        [HttpGet("/export/Localhost/cards/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCardsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Cards, Request.Query), fileName);
        }
        [HttpGet("/export/Localhost/categories/csv")]
        [HttpGet("/export/Localhost/categories/csv(fileName='{fileName}')")]
        public FileStreamResult ExportCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Categories, Request.Query), fileName);
        }

        [HttpGet("/export/Localhost/categories/excel")]
        [HttpGet("/export/Localhost/categories/excel(fileName='{fileName}')")]
        public FileStreamResult ExportCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Categories, Request.Query), fileName);
        }
        [HttpGet("/export/Localhost/clients/csv")]
        [HttpGet("/export/Localhost/clients/csv(fileName='{fileName}')")]
        public FileStreamResult ExportClientsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Clients, Request.Query), fileName);
        }

        [HttpGet("/export/Localhost/clients/excel")]
        [HttpGet("/export/Localhost/clients/excel(fileName='{fileName}')")]
        public FileStreamResult ExportClientsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Clients, Request.Query), fileName);
        }
        [HttpGet("/export/Localhost/sentences/csv")]
        [HttpGet("/export/Localhost/sentences/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSentencesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Sentences, Request.Query), fileName);
        }

        [HttpGet("/export/Localhost/sentences/excel")]
        [HttpGet("/export/Localhost/sentences/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSentencesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Sentences, Request.Query), fileName);
        }
    }
}
