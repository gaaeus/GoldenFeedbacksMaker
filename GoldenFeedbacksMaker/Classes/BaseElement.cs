using iText.Kernel.Font;

namespace GoldenFeedbacksMaker.Classes
{
    public class BaseElement
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string RegularFontName { get; set; }
        public string BoldFontName { get; set; }

        public PdfFont regularFont { get; set; }
        public PdfFont boldFont { get; set; }

        public void InitializeLayout()
        {
            if (string.IsNullOrEmpty(RegularFontName))
                RegularFontName = Common.FontTitleRegular;

            if (string.IsNullOrEmpty(BoldFontName))
                BoldFontName = Common.FontTitleBold;

            if (!PdfFontFactory.IsRegistered(RegularFontName))
                PdfFontFactory.Register(RegularFontName);
            if (!PdfFontFactory.IsRegistered(BoldFontName))
                PdfFontFactory.Register(BoldFontName);

            regularFont = PdfFontFactory.CreateFont(RegularFontName, true);
            boldFont = PdfFontFactory.CreateFont(BoldFontName, true);

        }
        
    }
}
