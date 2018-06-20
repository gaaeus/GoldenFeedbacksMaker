using GoldenFeedbacksMaker.Classes;
using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            for (var i = 1; i < 4; i++)
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

            document.Close();
        }
    }
}
