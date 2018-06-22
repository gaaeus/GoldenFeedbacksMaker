using GoldenFeedbacksMaker.Classes;
using GoldenFeedbacksMaker.Helpers;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using System;

namespace GoldenFeedbacksMaker
{
    class Program
    {
        public const String DEST = "TheGoldenFeedbacks.pdf";

        static void Main(string[] args)
        {
            CreateBook();
        }

        static void CreateBook()
        {
            var writer = new PdfWriter(DEST);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4);

            //document.SetMargins(20, 20, 20, 20);

            for (var i = 1; i < 10; i++)
            {
                Question q = new Question();
                q.Number = i;
                q.Content = "Thisis aquesti on :P";
                document.Add(q.GetQuestion());

                Answer a = new Answer();
                a.Number = 1;
                a.Content = "The structures involved in snoring are the uvula and the soft palate. The muscles of soft palate and uvula are: tensor veli palatine, palatoglossus, palatopharyngeus, levator veli palatine and musculus uvulae.";
                document.Add(a.GetAnswer());
            }

            Comment c = new Comment();
            c.Title = "Just a title";
            c.Content = "This is just a simple comment that should be in a comment section!";
            document.Add(c.GetComment());

            HeaderFooterHelper headerFooterHelper = new HeaderFooterHelper();
            Document doc = new Document(pdf);
            headerFooterHelper.AddHeaderAndFooter(pdf, ref doc, "The Golden Feedbacks 2018 - Anatomy", 1, 1);

            document.Close();
        }
       
    }
}
