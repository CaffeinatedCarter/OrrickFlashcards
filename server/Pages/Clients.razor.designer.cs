using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Flashcardgenerator.Models.Localhost;
using Microsoft.EntityFrameworkCore;

namespace Flashcardgenerator.Pages
{
    public partial class ClientsComponent : ComponentBase, IDisposable
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        [Inject]
        protected GlobalsService Globals { get; set; }

        public void Dispose()
        {
            Globals.PropertyChanged -= OnPropertyChanged;
        }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected LocalhostService Localhost { get; set; }
        protected RadzenGrid<Flashcardgenerator.Models.Localhost.Client> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<Flashcardgenerator.Models.Localhost.Client> _getClientsResult;
        protected IEnumerable<Flashcardgenerator.Models.Localhost.Client> getClientsResult
        {
            get
            {
                return _getClientsResult;
            }
            set
            {
                if (!object.Equals(_getClientsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClientsResult", NewValue = value, OldValue = _getClientsResult };
                    _getClientsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var localhostGetClientsResult = await Localhost.GetClients(new Query() { Filter = $@"i => i.longName.Contains(@0) || i.shortName.Contains(@1)", FilterParameters = new object[] { search, search }, Expand = "" });
            getClientsResult = localhostGetClientsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddClient>("Add Client", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Localhost.ExportClientsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "clientId,isCurrent,longName,shortName" }, $"Clients");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Localhost.ExportClientsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "clientId,isCurrent,longName,shortName" }, $"Clients");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Flashcardgenerator.Models.Localhost.Client args)
        {
            var dialogResult = await DialogService.OpenAsync<EditClient>("Edit Client", new Dictionary<string, object>() { {"clientId", args.clientId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var localhostDeleteClientResult = await Localhost.DeleteClient(data.clientId);
                    if (localhostDeleteClientResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception localhostDeleteClientException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Client" });
            }
        }
    }
}
