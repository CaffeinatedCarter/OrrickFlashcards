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
    public partial class SentencesComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<Flashcardgenerator.Models.Localhost.Sentence> grid0;

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

        IEnumerable<Flashcardgenerator.Models.Localhost.Sentence> _getSentencesResult;
        protected IEnumerable<Flashcardgenerator.Models.Localhost.Sentence> getSentencesResult
        {
            get
            {
                return _getSentencesResult;
            }
            set
            {
                if (!object.Equals(_getSentencesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSentencesResult", NewValue = value, OldValue = _getSentencesResult };
                    _getSentencesResult = value;
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

            var localhostGetSentencesResult = await Localhost.GetSentences(new Query() { Filter = $@"briefId eq ""{Globals.selectedBriefId}""" });
            getSentencesResult = localhostGetSentencesResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSentence>("Add Sentence", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Localhost.ExportSentencesToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Brief", Select = "Brief.briefType,content,sentenceId,verified" }, $"Sentences");

            }

            if (args == null || args.Value == "xlsx")
            {
                await Localhost.ExportSentencesToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Brief", Select = "Brief.briefType,content,sentenceId,verified" }, $"Sentences");

            }
        }

        protected async System.Threading.Tasks.Task ConvertToCardsClick(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddSentence>("Add Sentence", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(Flashcardgenerator.Models.Localhost.Sentence args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSentence>("Edit Sentence", new Dictionary<string, object>() { {"sentenceId", args.sentenceId} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var localhostDeleteSentenceResult = await Localhost.DeleteSentence(data.sentenceId);
                    if (localhostDeleteSentenceResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception localhostDeleteSentenceException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Sentence" });
            }
        }
    }
}
