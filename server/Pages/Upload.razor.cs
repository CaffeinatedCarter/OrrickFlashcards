using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using Flashcardgenerator.Models;
using DocumentFormat.OpenXml.InkML;
using PragmaticSegmenterNet;
using flashcardgenerator.Controllers;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Components.Web;
using Flashcardgenerator.Models.Localhost;
using Microsoft.EntityFrameworkCore;
using flashcardgenerator.Data;

namespace Flashcardgenerator.Pages
{
    public partial class UploadComponent
    {

        public async Task CreateSentencesFromLastUpload()
        {

            DocProcessing newDoc = new DocProcessing();

            newDoc.Process(UploadController.cGlobals.lastUploadDir);

            IList<string> strings = (IList<string>)Segmenter.Segment(newDoc.getAllText());

            int count = 0;

            try { 
            
            { foreach (string iter in strings)
            {

                Card c = new Card();
                c.Answer = iter;
                    if (Globals.selectedBriefId == null)
                    { c.briefId = 0; } else { 
                c.briefId = (int)Globals.selectedBriefId;
                    }
                    ;

                await Localhost.CreateCard(c);

                count++;


            }
            }
            }
            catch(System.Exception ArgumentException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Please upload a file." });

            }

        }
    }
}






