using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using BlazorDownloadFile;
using Microsoft.AspNetCore.Components;
using Flashcardgenerator.Models.Localhost;
using Aspose.Words;
using System.IO;
using Aspose.Words.Tables;
using System.Drawing;

namespace Flashcardgenerator.Pages
{
    public partial class LoadBriefComponent {

        public IList<Card> getSelectedCards;
        public int cardCount;


        [Inject] IBlazorDownloadFileService BlazorDownloadFileService { get; set; }

        [Inject] protected LocalhostService Lhs { get; set; }


        public async Task MergeCards(IList<Card> deck)

        {

            // TODO

            // Sorry, wasn't able to get this iteration working properly. Don't know why, will keep looking.

            //var firstCard = deck.First();
            //string mergeText = "";


            //foreach (Card c in deck)
            //{
            //   mergeText = mergeText + " " + c.Answer;

            //}

            //foreach (Card d in deck.Skip(1))
            //{
            //    await Lhs.DeleteCard(d.cardId);
            //}


            //firstCard.Answer = mergeText;

        }

        public async Task DeleteManyCards(IList<Card> deck)

        {

            // TODO

            // Sorry, wasn't able to get this iteration working properly. Don't know why, will keep looking.

            //if(deck == null || deck.Count() == 0)
            //{
            //    return;
            //}
            //foreach (Card d in deck)
            //{
            //    _ = await Lhs.DeleteCard(d.cardId);
            //}


        }



        public void ExportBrief(IEnumerable<Card> deck)
        {

            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            Table table = builder.StartTable();

            foreach (Card c in deck)
            {
                builder.InsertCell();
                if(c.Question == null)
                {
                    builder.Write("");
                } else {
                    builder.Write(c.Question);
                }
                

                // Build the second cell
                builder.InsertCell();
                if(c.Answer == null)
                {
                    builder.Write("");
                } else {
                    builder.Write(c.Answer);
                }

                // Call the following method to end the row and start a new row.
                builder.EndRow();

            }


            table.SetBorders(LineStyle.None, 0, Color.White); ;

            // Signal that we have finished building the table.
            builder.EndTable();


            MemoryStream dstStream = new MemoryStream();
            doc.Save(dstStream, SaveFormat.Docx);

            BlazorDownloadFileService.DownloadFile("out.docx", dstStream, "application/octet-stream");
        }

        public void UpdateSelection(Card card)
        {
            if (getSelectedCards.Contains(card))
            {
                getSelectedCards.Remove(card);
            }
            else
            {
                getSelectedCards.Add(card);
            }

            StateHasChanged();
        }


    }
    }

