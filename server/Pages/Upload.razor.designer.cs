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
    public partial class UploadComponent : ComponentBase, IDisposable
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
        protected RadzenUpload upload0;

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            Globals.PropertyChanged += OnPropertyChanged;
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var localhostGetClientsResult = await Localhost.GetClients();
            getClientsResult = localhostGetClientsResult;

            var localhostGetBriefsResult = await Localhost.GetBriefs();
            getBriefsResult = localhostGetBriefsResult;
        }

        protected async System.Threading.Tasks.Task Upload0Complete(UploadCompleteEventArgs args)
        {
            TooltipService.Open(upload0.Element, $"Upload succeeded!", new TooltipOptions(){ Duration = 200000000,Position = TooltipPosition.Right });
        }

        protected async System.Threading.Tasks.Task Upload0Error(UploadErrorEventArgs args)
        {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"File Upload failed",Detail = $"{args.Message}",Duration = 20 });
        }
    }
}
