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
    public partial class HomeComponent : ComponentBase, IDisposable
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

        IEnumerable<Flashcardgenerator.Models.Localhost.Brief> _getBriefs;
        protected IEnumerable<Flashcardgenerator.Models.Localhost.Brief> getBriefs
        {
            get
            {
                return _getBriefs;
            }
            set
            {
                if (!object.Equals(_getBriefs, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getBriefs", NewValue = value, OldValue = _getBriefs };
                    _getBriefs = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _showProgress;
        protected bool showProgress
        {
            get
            {
                return _showProgress;
            }
            set
            {
                if (!object.Equals(_showProgress, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "showProgress", NewValue = value, OldValue = _showProgress };
                    _showProgress = value;
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
            var localhostGetBriefsResult = await Localhost.GetBriefs(new Query() { Expand = "Client" });
            getBriefs = localhostGetBriefsResult;

            Globals.selectedBriefId = 0;

            Globals.progressBarVal = 0;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddBrief>("Add Brief", null);
        }

        protected async System.Threading.Tasks.Task UploadFileClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<Upload>("Upload", null);
        }

        protected async System.Threading.Tasks.Task ProcessFileClick(MouseEventArgs args)
        {
            try
            {
                await CreateSentencesFromLastUpload();
            }
            catch (System.Exception createSentencesFromLastUploadException)
            {
            showProgress = false;
            }

            showProgress = true;
        }

        protected async System.Threading.Tasks.Task GoClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo("load-brief");
        }

        protected async System.Threading.Tasks.Task DropdownDatagrid0Change(dynamic args)
        {
            Globals.selectedBriefId = args;
        }

    }
}
