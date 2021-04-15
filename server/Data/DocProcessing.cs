using System.Collections.Generic;
using Aspose.Words;
using Flashcardgenerator;
using Microsoft.AspNetCore.Components;
using PragmaticSegmenterNet;

namespace flashcardgenerator.Data
{

    public class DocProcessing
    {
        public string allText;

        public int briefId;

        public void Process(string dir) {

            Document processDoc = new Document(dir);

            allText = processDoc.ToString(SaveFormat.Text);

        }

        public string getAllText()
        {
            return allText;
        }

        public void Process(Document doc)
        {
            Document processDoc = doc;
            RemovePageBreaks(processDoc);
            allText = processDoc.ToString(SaveFormat.Text);
        }


        private static void RemovePageBreaks(Document doc)
        {
            // Retrieve all paragraphs in the document.
            NodeCollection paragraphs = doc.GetChildNodes(NodeType.Paragraph, true);

            // Iterate through all paragraphs
            foreach (Paragraph para in paragraphs)
            {
                // If the paragraph has a page break before set then clear it.
                if (para.ParagraphFormat.PageBreakBefore)
                    para.ParagraphFormat.PageBreakBefore = false;

                // Check all runs in the paragraph for page breaks and remove them.
                foreach (Run run in para.Runs)
                {
                    if (run.Text.Contains(ControlChar.PageBreak))
                        run.Text = run.Text.Replace(ControlChar.PageBreak, string.Empty);
                } } }

        public string Text => allText;


    } }



    




   


