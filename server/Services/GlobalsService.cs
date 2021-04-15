using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Flashcardgenerator.Models;
using Flashcardgenerator.Models.Localhost;
using Radzen;

namespace Flashcardgenerator
{
    public partial class GlobalsService
    {
        public event Action<PropertyChangedEventArgs> PropertyChanged;


        int _selectedBriefId;
        public int selectedBriefId
        {
            get
            {
                return _selectedBriefId;
            }
            set
            {
                if(!object.Equals(_selectedBriefId, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "selectedBriefId", NewValue = value, OldValue = _selectedBriefId, IsGlobal = true };
                    _selectedBriefId = value;
                    PropertyChanged?.Invoke(args);
                }
            }
        }

        int _progressBarVal;
        public int progressBarVal
        {
            get
            {
                return _progressBarVal;
            }
            set
            {
                if(!object.Equals(_progressBarVal, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "progressBarVal", NewValue = value, OldValue = _progressBarVal, IsGlobal = true };
                    _progressBarVal = value;
                    PropertyChanged?.Invoke(args);
                }
            }
        }
    }

    public class PropertyChangedEventArgs
    {
        public string Name { get; set; }
        public object NewValue { get; set; }
        public object OldValue { get; set; }
        public bool IsGlobal { get; set; }
    }
}
