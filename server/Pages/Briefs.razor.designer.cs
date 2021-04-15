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
    public partial class BriefsComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<Flashcardgenerator.Models.Localhost.Brief> grid0;
        protected RadzenGrid<Flashcardgenerator.Models.Localhost.Card> grid1;

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

        IEnumerable<Flashcardgenerator.Models.Localhost.Brief> _getBriefsResult;
        protected IEnumerable<Flashcardgenerator.Models.Localhost.Brief> getBriefsResult
        {
            get
            {
                return _getBriefsResult;
            }
            set
            {
                if (!object.Equals(_getBriefsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBriefsResult", NewValue = value, OldValue = _getBriefsResult };
                    _getBriefsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        dynamic _master;
        protected dynamic master
        {
            get
            {
                return _master;
            }
            set
            {
                if (!object.Equals(_master, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "master", NewValue = value, OldValue = _master };
                    _master = value;
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

            var localhostGetBriefsResult = await Localhost.GetBriefs(new Query() { Filter = $@"i => i.briefType.Contains(@0) || i.opposingParty.Contains(@1)", FilterParameters = new object[] { search, search }, Expand = "Client" });
            getBriefsResult = localhostGetBriefsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddBrief>("Add Brief", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Localhost.ExportBriefsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Client", Select = "briefId,briefType,Client.longName,isTestBrief,opposingParty" }, $"Brief 2");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Localhost.ExportBriefsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Client", Select = "briefId,briefType,Client.longName,isTestBrief,opposingParty" }, $"Brief 2");

            }
        }

        protected async System.Threading.Tasks.Task Grid0RowExpand(Flashcardgenerator.Models.Localhost.Brief args)
        {
            master = args;

            var localhostGetCardsResult = await Localhost.GetCards(new Query() { Filter = $@"i => i.briefId == {args.briefId}" });
            if (localhostGetCardsResult != null)
            {
                args.Cards = localhostGetCardsResult.ToList();
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Flashcardgenerator.Models.Localhost.Brief args)
        {
            var dialogResult = await DialogService.OpenAsync<EditBrief>("Edit Brief", new Dictionary<string, object>() { {"briefId", args.briefId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var localhostDeleteBriefResult = await Localhost.DeleteBrief(data.briefId);
                    if (localhostDeleteBriefResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception localhostDeleteBriefException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Brief" });
            }
        }

        protected async System.Threading.Tasks.Task CardAddButtonClick(MouseEventArgs args, dynamic data)
        {
            var dialogResult = await DialogService.OpenAsync<AddCard>("Add Card", new Dictionary<string, object>() { {"briefId", data.briefId} });
            await grid1.Reload();
        }

        protected async System.Threading.Tasks.Task Grid1RowSelect(Flashcardgenerator.Models.Localhost.Card args, dynamic data)
        {
            var dialogResult = await DialogService.OpenAsync<EditCard>("Edit Card", new Dictionary<string, object>() { {"cardId", args.cardId} });
            await grid1.Reload();
        }

        protected async System.Threading.Tasks.Task CardDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var localhostDeleteCardResult = await Localhost.DeleteCard(data.cardId);
                    if (localhostDeleteCardResult != null)
                    {
                        await grid1.Reload();
                    }
                }
            }
            catch (System.Exception localhostDeleteCardException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Brief" });
            }
        }
    }
}
