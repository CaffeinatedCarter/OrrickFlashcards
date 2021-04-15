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
    public partial class AddSentenceComponent : ComponentBase, IDisposable
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

        Flashcardgenerator.Models.Localhost.Sentence _sentence;
        protected Flashcardgenerator.Models.Localhost.Sentence sentence
        {
            get
            {
                return _sentence;
            }
            set
            {
                if (!object.Equals(_sentence, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "sentence", NewValue = value, OldValue = _sentence };
                    _sentence = value;
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
            var localhostGetBriefsResult = await Localhost.GetBriefs(new Query() { Expand = "Client,Brief($expand=Client)" });
            getBriefsResult = localhostGetBriefsResult;

            sentence = new Flashcardgenerator.Models.Localhost.Sentence(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Flashcardgenerator.Models.Localhost.Sentence args)
        {
            try
            {
                var localhostCreateSentenceResult = await Localhost.CreateSentence(sentence);
                DialogService.Close(sentence);
            }
            catch (System.Exception localhostCreateSentenceException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Sentence!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
