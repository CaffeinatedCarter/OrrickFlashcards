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
    public partial class AddBriefComponent : ComponentBase, IDisposable
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

        IEnumerable<Flashcardgenerator.Models.Localhost.Client> _getClientsForclientIdResult;
        protected IEnumerable<Flashcardgenerator.Models.Localhost.Client> getClientsForclientIdResult
        {
            get
            {
                return _getClientsForclientIdResult;
            }
            set
            {
                if (!object.Equals(_getClientsForclientIdResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getClientsForclientIdResult", NewValue = value, OldValue = _getClientsForclientIdResult };
                    _getClientsForclientIdResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        Flashcardgenerator.Models.Localhost.Brief _brief;
        protected Flashcardgenerator.Models.Localhost.Brief brief
        {
            get
            {
                return _brief;
            }
            set
            {
                if (!object.Equals(_brief, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "brief", NewValue = value, OldValue = _brief };
                    _brief = value;
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
            var localhostGetClientsResult = await Localhost.GetClients();
            getClientsForclientIdResult = localhostGetClientsResult;

            brief = new Flashcardgenerator.Models.Localhost.Brief(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(Flashcardgenerator.Models.Localhost.Brief args)
        {
            try
            {
                var localhostCreateBriefResult = await Localhost.CreateBrief(brief);
                DialogService.Close(brief);
            }
            catch (System.Exception localhostCreateBriefException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Brief!" });
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddClient>("Add Client", null);
        }

        protected async System.Threading.Tasks.Task Button3Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
