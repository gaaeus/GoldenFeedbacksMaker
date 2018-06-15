using GoldenFeedbacksMaker.Classes;
using iText.IO.Font;
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

            Question q = new Question();
            q.Number = 1;
            q.Content = "Thisis a question";
            document.Add(q.GetQuestion());

            Answer a = new Answer();
            a.Number = 1;
            a.Content = "The structures involved in snoring are the uvula and the soft palate. The muscles of soft palate and uvula are: tensor veli palatine, palatoglossus, palatopharyngeus, levator veli palatine and musculus uvulae.";
            document.Add(a.GetAnswer());

            //document.Add(new Paragraph("Hello World!"));

            document.Close();
        }
    }
}
