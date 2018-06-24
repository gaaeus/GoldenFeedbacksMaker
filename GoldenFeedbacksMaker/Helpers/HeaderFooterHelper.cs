using GoldenFeedbacksMaker.Classes;
using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace GoldenFeedbacksMaker.Helpers
{
    public class HeaderFooterHelper : BaseElement
    {
        float HeaderX { get; set; }
        float HeaderY { get; set; }

        float FooterX { get; set; }
        float FooterY { get; set; }

        public HeaderFooterHelper()
        {
            RegularFontName = Common.FontTitleRegular;
            InitializeLayout();
        }

        public void AddHeaderAndFooter(PdfDocument document, ref Document doc, string headerTitle, int startPage, int endPage)
        {
            Paragraph header = new Paragraph(headerTitle).SetFont(regularFont).SetFontSize(10).SetFontColor(new DeviceCmyk(0, 0, 0, 0.7f));
            bool setRight = false;
            TextAlignment textAlignment = TextAlignment.RIGHT;

            for (int i = startPage; i < endPage; i++)
            {
                setRight = (i % 2 == 1);
                textAlignment = setRight ? TextAlignment.RIGHT : TextAlignment.LEFT;

                // Header
                HeaderX = document.GetPage(i).GetPageSize().GetWidth();
                if (setRight)
                    HeaderX = HeaderX - 30;
                else
                    HeaderX = 30;

                HeaderY = document.GetPage(i).GetPageSize().GetTop() - 40;
                doc.ShowTextAligned(header, HeaderX, HeaderY, i, textAlignment, VerticalAlignment.BOTTOM, 0);

                //Footer
                FooterX = document.GetPage(i).GetPageSize().GetWidth();
                if (setRight)
                    FooterX = FooterX - 30;
                else
                    FooterX = 30;

                Paragraph footer = new Paragraph($"Page {i}").SetFont(regularFont).SetFontSize(10).SetFontColor(new DeviceCmyk(0, 0, 0, 0.7f));

                FooterY = document.GetPage(i).GetPageSize().GetBottom() + 40;
                doc.ShowTextAligned(footer, FooterX, FooterY, i, textAlignment, VerticalAlignment.TOP, 0);

            }
        }
    }
}
