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
    public partial class LoadBriefComponent : ComponentBase, IDisposable
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
        protected RadzenGrid<Flashcardgenerator.Models.Localhost.Card> grid0;

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

        IEnumerable<Flashcardgenerator.Models.Localhost.Category> _getCategoriesResult;
        protected IEnumerable<Flashcardgenerator.Models.Localhost.Category> getCategoriesResult
        {
            get
            {
                return _getCategoriesResult;
            }
            set
            {
                if (!object.Equals(_getCategoriesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCategoriesResult", NewValue = value, OldValue = _getCategoriesResult };
                    _getCategoriesResult = value;
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

        Flashcardgenerator.Models.Localhost.Card _card;
        protected Flashcardgenerator.Models.Localhost.Card card
        {
            get
            {
                return _card;
            }
            set
            {
                if (!object.Equals(_card, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "card", NewValue = value, OldValue = _card };
                    _card = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        IEnumerable<Flashcardgenerator.Models.Localhost.Card> _getCardsResult;
        protected IEnumerable<Flashcardgenerator.Models.Localhost.Card> getCardsResult
        {
            get
            {
                return _getCardsResult;
            }
            set
            {
                if (!object.Equals(_getCardsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getCardsResult", NewValue = value, OldValue = _getCardsResult };
                    _getCardsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        Flashcardgenerator.Models.Localhost.Brief _briefObj;
        protected Flashcardgenerator.Models.Localhost.Brief briefObj
        {
            get
            {
                return _briefObj;
            }
            set
            {
                if (!object.Equals(_briefObj, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "briefObj", NewValue = value, OldValue = _briefObj };
                    _briefObj = value;
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
            var localhostGetBriefsResult = await Localhost.GetBriefs(new Query() { Filter = $@"briefId eq ""{Globals.selectedBriefId}""" });
            getBriefsResult = localhostGetBriefsResult;

            var localhostGetCategoriesResult = await Localhost.GetCategories();
            getCategoriesResult = localhostGetCategoriesResult;

            var localhostGetSentencesResult = await Localhost.GetSentences();
            getSentencesResult = localhostGetSentencesResult;

            card = new Flashcardgenerator.Models.Localhost.Card(){};

            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var localhostGetCardsResult = await Localhost.GetCards(new Query() { Filter = $@"briefId eq ""{Globals.selectedBriefId}""", Expand = "Brief,Category,Sentence" });
            getCardsResult = localhostGetCardsResult;

            var localhostGetBriefBybriefIdResult = await Localhost.GetBriefBybriefId(Globals.selectedBriefId);
            briefObj = localhostGetBriefBybriefIdResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.grid0.InsertRow(new Flashcardgenerator.Models.Localhost.Card());
        }

        protected async System.Threading.Tasks.Task DownloadClick(MouseEventArgs args)
        {
            ExportBrief(getCardsResult);
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            try
            {
                MergeCards(getSelectedCards);
            }
            catch (System.Exception mergeCardsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Failed to merge." });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            await DeleteManyCards(getSelectedCards);
        }

        protected async System.Threading.Tasks.Task Grid0RowCreate(dynamic args)
        {
            var localhostCreateCardResult = await Localhost.CreateCard(args);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(Flashcardgenerator.Models.Localhost.Card args)
        {
            await DialogService.OpenAsync<EditCard>("Edit Card", new Dictionary<string, object>() { {"cardId", args.cardId} });
        }

        protected async System.Threading.Tasks.Task Grid0RowUpdate(dynamic args)
        {
            var localhostUpdateCardResult = await Localhost.UpdateCard(args.cardId, args);
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var localhostDeleteCardResult = await Localhost.DeleteCard(data.cardId);
                    if (localhostDeleteCardResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception localhostDeleteCardException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Card" });
            }
        }
    }
}
