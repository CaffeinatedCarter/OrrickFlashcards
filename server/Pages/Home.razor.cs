using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using flashcardgenerator.Data;
using flashcardgenerator.Controllers;
using PragmaticSegmenterNet;
using Flashcardgenerator.Models.Localhost;
using Microsoft.AspNetCore.Components;

namespace Flashcardgenerator.Pages
{
    public partial class HomeComponent
    {

        public void ChangeSelectedBrief(int bId)
            {
                Globals.selectedBriefId = bId;
            }
        
        public async Task CreateSentencesFromLastUpload()
        {

            DocProcessing newDoc = new DocProcessing();

            try { 
            newDoc.Process(UploadController.cGlobals.lastUploadDir);
            }
            catch(System.Exception ArgumentException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Please upload a file." });

            }
            IList<string> strings = (IList<string>)Segmenter.Segment(newDoc.getAllText());

            int listCount = (strings).Count;

            int count = 0;

            try
            {

                {
                    foreach (string iter in strings)
                    {
                        Globals.progressBarVal = (int)(count);

                        Card c = new Card();
                        c.Answer = iter;
                    
                        {
                            c.briefId = (int)Globals.selectedBriefId;
                        }
                          ;

                        await Localhost.CreateCard(c);

                        count++;


                    }
                }
            }
            catch (System.Exception ArgumentException)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Error", Detail = $"Processing failed." });

            }

        }
    }
}
